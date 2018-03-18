using System;
using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnityViewServiceV2 : IViewService
{
    private Dictionary<string, ObjectPool> _pools;
    private List<AssetBundle> _loadedBundles;

    private readonly Contexts _contexts;

    private bool isRepopulating = false;

    public UnityViewServiceV2 (Contexts contexts, string[] paths)
    {
        _pools = new Dictionary<string, ObjectPool>();
        _loadedBundles = new List<AssetBundle>();
        _contexts = contexts;
        Repopulate(true, paths);
    }

    public void Load (IContext context, IEntity entity, string name)
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

    public void Repopulate (bool includeSceneObjects, string[] paths = null)
    {
        if (isRepopulating) { return; }
        isRepopulating = true;

        this.Cleanup().completed += (res) =>
        {
            //get scene objs first
            if (includeSceneObjects)
            {
                var sceneObjs = SceneManager.GetActiveScene().GetRootGameObjects()
                                            .SelectMany(obj => obj.GetComponentsInChildren<IView>())
                                            .Select(obj => obj.Instance);
                foreach (var obj in sceneObjs)
                {
                    var view = obj.GetComponent<IView>();

                    if (_pools.ContainsKey(obj.name) == false)
                    {
                        _pools.Add(obj.name, new ObjectPool(obj.name, obj, 0));
                    }
                }
            }

            //load from asset bundles
            if (paths != null && paths.Length > 0)
            {
                int numBundles = paths.Length;
                int finBundles = 0;
                foreach (var path in paths)
                {
                    var fileRequest = AssetBundle.LoadFromFileAsync(path);
                    fileRequest.completed += (op) =>
                    {
                        finBundles++;
                        var assets = fileRequest.assetBundle.LoadAllAssets<GameObject>();
                        foreach (var obj in assets)
                        {
                            obj.SetActive(false);
                            _pools.Add(obj.name, new ObjectPool(obj.name, obj));
                        }

                        if (finBundles == numBundles)
                        {
                            Finish();
                        }
                    };
                }
            }
            else
            {
                Finish();
            }
        };

    }

    void Finish ()
    {
        isRepopulating = false;
        //change to input later
        _contexts.game.isLoadedViewsComplete = true;
    }

    AsyncOperation Cleanup ()
    {
        _pools = new Dictionary<string, ObjectPool>();

        foreach (var bundle in _loadedBundles)
        {
            bundle.Unload(true);
        }

        return Resources.UnloadUnusedAssets();
    }

}
