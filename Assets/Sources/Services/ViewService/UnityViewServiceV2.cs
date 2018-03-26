using System;
using System.Collections.Generic;
using UniRx;
using System.Linq;
using Entitas;
using UnityEngine;
using UnityEngine.SceneManagement;
using AssetBundles;

public class UnityViewServiceV2 : IViewService
{
    private Dictionary<string, ObjectPool> _pools;
    private List<AssetBundle> _loadedBundles;

    private readonly Contexts _contexts;

    private AssetBundleManager _manager;

    public UnityViewServiceV2 (Contexts contexts)
    {
        _pools = new Dictionary<string, ObjectPool>();
        _loadedBundles = new List<AssetBundle>();
        _contexts = contexts;
    }

    public IObservable<T> GetAsset<T> (string name) where T : UnityEngine.Object
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

                    return LoadAssets(includeSceneObjects, bundles);
                }).Merge();
            }
            else
            {
                return LoadAssets(includeSceneObjects, bundles);
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
    }

    private IObservable<bool> LoadAssets (bool includeSceneObjects, string[] bundles = null)
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

    private GameObject[] GetActiveSceneObjects ()
    {
        return SceneManager.GetActiveScene().GetRootGameObjects()
                                        .SelectMany(obj => obj.GetComponentsInChildren<IView>())
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
