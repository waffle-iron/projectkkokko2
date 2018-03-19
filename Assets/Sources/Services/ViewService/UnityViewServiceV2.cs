using System;
using System.Collections.Generic;
using System.Threading;
using UniRx;
using System.Linq;
using Entitas;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnityViewServiceV2 : IViewService
{
    private Dictionary<string, ObjectPool> _pools;
    private List<AssetBundle> _loadedBundles;

    private readonly Contexts _contexts;

    public UnityViewServiceV2 (Contexts contexts, string[] paths)
    {
        _pools = new Dictionary<string, ObjectPool>();
        _loadedBundles = new List<AssetBundle>();
        _contexts = contexts;
        Populate(true, paths);
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

        //load from asset bundles
        if (bundles != null && bundles.Length > 0)
        {
            var loaders = new List<IObservable<Unit>>();

            foreach (var path in bundles)
            {
                var loader = AssetBundle.LoadFromFileAsync(path)
                    .AsAsyncOperationObservable()
                    .Where(request => request.isDone)
                    .Select(request =>
                    {
                        return request.assetBundle.LoadAllAssetsAsync<GameObject>()
                        .AsAsyncOperationObservable()
                        .Where(assets => assets.isDone)
                        .Select(assets =>
                        {
                            AddToPool(assets.allAssets.Select(obj => obj as GameObject).ToArray());
                            _loadedBundles.Add(request.assetBundle);
                            return Observable.ReturnUnit();
                        });

                    }).Merge().Merge();

                loaders.Add(loader);
            }

            return loaders.ToObservable().Merge().Aggregate<Unit, int>(0, (count, result) => count++)
                    .Where(count => count == bundles.Length)
                    .Select(_ => true);
        }
        else
        {
            return Observable.Return<bool>(true);
        }

    }

    //remove all null references
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
    }

    public void Unload (string bundle)
    {
        var newBundles = new List<AssetBundle>();
        foreach (var result in _loadedBundles)
        {
            if (result.name.Equals(bundle))
            {
                result.Unload(true);
            }
            else
            {
                newBundles.Add(result);
            }
        }

        _loadedBundles = newBundles;
        Clean();
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
