using System;
using System.Collections.Generic;
using UniRx;
using System.Linq;
using Entitas;
using UnityEngine;
using UnityEngine.SceneManagement;
using AssetBundles;
using UnityEditor;

public class UnityViewServiceV2 : IViewService
{
    private Dictionary<string, ObjectPool> _pools;
    private List<AssetBundle> _loadedBundles;
    private List<string> _loadedBundlesSimulation;

    private readonly Contexts _contexts;

    private AssetBundleManager _manager;

    private bool _isSimulationMode = false;

    private MetaContext _meta;

    public UnityViewServiceV2 (Contexts contexts, bool isSimulationMode)
    {
        _pools = new Dictionary<string, ObjectPool>();
        _loadedBundles = new List<AssetBundle>();
        _loadedBundlesSimulation = new List<string>();
        _contexts = contexts;
        _isSimulationMode = isSimulationMode;
        _meta = Contexts.sharedInstance.meta;
    }

    public IObservable<bool> CombineLoadAssets (IObservable<bool>[] observables)
    {
        return observables.CombineLatestValuesAreAllTrue();
    }

    public IObservable<bool> GetAsset<T> (string name, Action<T> action) where T : UnityEngine.Object
    {
        if (action == null) { Debug.LogError("ACTION IS NULL"); }
        return this.GetAsset<T>(name).Select(value =>
        {
            if (value != null)
            {
                action(value);
                return true;
            }
            else
            {
                Contexts.sharedInstance.meta.debugService.instance.LogError($"cannot find and load asset {name}");
                return true;
            }
        });
    }

    public IObservable<T> GetAsset<T> (string name) where T : UnityEngine.Object
    {
        var debug = _contexts.meta.debugService.instance;

#if UNITY_EDITOR
        if (_isSimulationMode)
        {
            return _loadedBundlesSimulation.ToObservable()
                    .Select(bundle =>
                    {
                        var result = AssetDatabase.GetAssetPathsFromAssetBundleAndAssetName(bundle, name);
                        debug.Log($"getting asset {name} from bundle {bundle} = {result != null || result.Length > 0}");
                        return result;
                    })
                    .Where(assetPaths => assetPaths.Length > 0)
                    .Select(assetPaths => assetPaths[0])
                    .Select(path =>
                    {
                        UnityEngine.Object target = AssetDatabase.LoadAssetAtPath<T>(path);
                        return new AssetBundleLoadAssetOperationSimulation(target);
                    })
                    .Where(op => op.IsDone())
                    .Select(op =>
                    {
                        var asset = op.GetAsset<T>();

                        return asset;
                    });
        }
        else
#endif
        {
            return _loadedBundles.ToObservable()
            .SelectMany(bundle =>
            {
                return bundle.LoadAssetAsync<T>(name).AsAsyncOperationObservable()
                .Where(request => request.isDone && request.asset != null)
                .Select(request =>
                {
                    return request.asset as T;
                });
            }).First();
        }
    }


    public void Instantiate (IContext context, IEntity entity, string name)
    {
        ObjectPool pool = null;
        if (_pools.TryGetValue(name, out pool))
        {
            var views = pool.Get().GetComponentsInChildren<IView>();
            foreach (var view in views)
            {
                view.Link(entity, context);
            }
        }
        else
        {
            Debug.LogWarning($"view: {name} does not exist in the pool or in scene {SceneManager.GetActiveScene().name}");
        }
    }


    public IObservable<bool> Populate (bool includeSceneObjects, string[] bundles = null)
    {
        if (includeSceneObjects)
        {
            var sceneObjs = GetActiveSceneObjects();
            AddToPool(sceneObjs);
        }

        if (_isSimulationMode)
        {
            Contexts.sharedInstance.meta.viewService.isInitialized = true;
            return LoadGameObjects(bundles);
        }

        if (bundles != null && bundles.Length > 0)
        {
            if (_manager == null)
            {
                //init manager then load assets
                return Observable.FromCoroutine<AssetBundleManager>((observer, token) =>
                {
                    return AssetBundleLoader.Init(null, observer, token);
                })
                .Where(manager => manager != null)
                .Select(manager =>
                {
                    this._manager = manager;
                    Contexts.sharedInstance.meta.viewService.isInitialized = true;

                    return LoadGameObjects(bundles);
                }).Merge();
            }
            else
            {
                return LoadGameObjects(bundles);
            }
        }
        else
        {
            return Observable.Return<bool>(true);
        }

    }

    //remove all null references and unload resources not used
    public void Clean ()
    {
        var newPool = new Dictionary<string, ObjectPool>();
        foreach (var pool in _pools)
        {
            pool.Value.Cleanup();

            if (pool.Value.IsEmpty == false)
            {
                newPool.Add(pool.Key, pool.Value);
            }
        }

        _pools = newPool;
        Resources.UnloadUnusedAssets();
    }

    public void Unload (string bundle)
    {
        var result = _loadedBundles.Find(bdl => bdl.name.Equals(bundle));
        if (result != null) { _loadedBundles.Remove(result); }
        _manager.UnloadBundle(bundle, true, true);
        Clean();

        if (_isSimulationMode) { _loadedBundlesSimulation.Remove(bundle); }
    }

    private IObservable<bool> LoadGameObjects (string[] bundles)
    {
        var debug = _contexts.meta.debugService.instance;

#if UNITY_EDITOR
        if (_isSimulationMode)
        {
            if (bundles == null || bundles.Length == 0)
            {
                _contexts.meta.debugService.instance.Log("no bundles to load and pool");
                return Observable.Return<bool>(true);
            }

            return bundles.ToObservable()
                    .Select(bundle =>
                    {
                        var paths = AssetDatabase.GetAssetPathsFromAssetBundle(bundle);
                        _loadedBundlesSimulation.Add(bundle);
                        //debug.Log($"sim paths: {paths.Count()}");
                        return paths;
                    })
                    .Select(paths =>
                    {
                        if (paths == null || paths.Length == 0)
                        {
                            return null;
                        }

                        var objs = new List<AssetBundleLoadAssetOperationSimulation>();

                        foreach (var path in paths)
                        {
                            UnityEngine.Object target = AssetDatabase.LoadMainAssetAtPath(path);
                            if (target is GameObject)
                            {
                                //debug.Log($"added object: {target.name}");
                                objs.Add(new AssetBundleLoadAssetOperationSimulation(target));
                            }
                        }

                        return objs;
                    })
                    .Select(op =>
                    {
                        if (op == null || op.Count == 0)
                        {
                            _contexts.meta.debugService.instance.Log("no views to pool");
                            return true;
                        }

                        AddToPool(op.Select(p => p.GetAsset<GameObject>()).ToArray());
                        return true;
                    });
        }
        else
#endif
        {
            return Observable.FromCoroutine<AssetBundle>((observer, token) => AssetBundleLoader.LoadBundle(this._manager, bundles, observer, token))
            .Where(bundle => bundle != null)
            .Select(bundle =>
            {
                _loadedBundles.Add(bundle);
                return AssetBundleLoader.LoadAllAssetsArray<GameObject>(bundle);
            })
            .Merge()
            .Select(objs =>
            {
                AddToPool(objs);
                return true;
            });
        }

    }

    private GameObject[] GetActiveSceneObjects ()
    {
        return SceneManager.GetActiveScene().GetRootGameObjects()
                                        .SelectMany(obj => obj.GetComponentsInChildren<IView>(true))
                                        .Select(obj => obj.Instance)
                                        .ToArray();
    }

    private void AddToPool (GameObject[] objs)
    {
        foreach (var obj in objs)
        {
            if (_pools.ContainsKey(obj.name) == false)
            {
                _pools.Add(obj.name, new ObjectPool(obj.name, obj, 0));
            }
        }
    }

}
