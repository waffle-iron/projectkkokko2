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

    private readonly Contexts _contexts;

    private AssetBundleManager _manager;

    public UnityViewServiceV2 (Contexts contexts)
    {
        _pools = new Dictionary<string, ObjectPool>();
        _contexts = contexts;

        //uses streaming assets only
        Observable.FromCoroutine<AssetBundleManager>((observer, token) =>
        {
            return AssetBundleLoader.Init(null, observer, token);
        })
        .Where(manager => manager != null)
        .Subscribe(manager =>
        {
            this._manager = manager;
            contexts.meta.viewService.isInitialized = true;
        });
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
        if (_manager == null)
        {
            Debug.LogError("Manager not yet initialized");
            return Observable.Return<bool>(false);
        }

        if (includeSceneObjects)
        {
            var sceneObjs = GetActiveSceneObjects();
            AddToPool(sceneObjs);
        }

        if (bundles != null && bundles.Length > 0)
        {
            return Observable.FromCoroutine<AssetBundle>((observer, token) => AssetBundleLoader.LoadBundle(this._manager, bundles, observer, token))
            .Where(bundle => bundle != null)
            .Select(bundle =>
            {
                return AssetBundleLoader.LoadAllAssetsArray<GameObject>(bundle);
            })
            .Merge()
            .Select(objs =>
            {
                AddToPool(objs);
                return true;
            });
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
        _manager.UnloadBundle(bundle, true, true);
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
