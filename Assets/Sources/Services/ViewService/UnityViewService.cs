using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnityViewService : IViewService
{
    private static Dictionary<string, List<GameObject>> _pool;

    public UnityViewService (bool includeActiveSceneObjs, string[] paths = null)
    {
        _pool = new Dictionary<string, List<GameObject>>();
        Refresh(includeActiveSceneObjs, paths);
    }

    public void Load (IContext context, IEntity entity, string name)
    {
        List<GameObject> objs = null;
        IView[] views = null;
        GameObject newObj = null;

        if (_pool.TryGetValue(name, out objs))
        {

            while (objs.Count > 1)
            {
                var index = objs.Count - 1;
                newObj = objs[index];
                objs.RemoveAt(index);

                if (newObj != null)
                {
                    break;
                }
            }
            if (newObj == null)
            {
                var objTransform = objs[0].transform;
                newObj = GameObject.Instantiate(objTransform.gameObject, objTransform.position, objTransform.rotation, objTransform.parent);
            }

            newObj.name = name;
            //newObj.hideFlags = HideFlags.None;
            newObj.SetActive(true);
            views = newObj.GetComponentsInChildren<IView>();
        }
        else
        {
            //get from resources folder if not yet loaded
            var obj = Resources.Load<GameObject>(name);
            if (obj != null)
            {
                AddToPool(new GameObject[] { obj });
                newObj = GameObject.Instantiate(obj, obj.transform.position, obj.transform.rotation, obj.transform.parent);
                //newObj.hideFlags = HideFlags.None;
                newObj.name = name;
                newObj.SetActive(true);
                views = newObj.GetComponentsInChildren<IView>();
            }
            else
            {
                Debug.LogWarning($"view: {name} does not exist in the pool or in scene {SceneManager.GetActiveScene().name}");
            }
        }

        if (newObj != null && views != null)
        {
            foreach (var view in views)
            {
                view.Link(entity, context);
                view.Instance.SetActive(true);
            }
        }
    }

    public static void Unload (IView views)
    {
        if (views != null)
        {
            views.Instance.SetActive(false);
            AddToPool(new GameObject[] { views.Instance });
        }
    }

    private void CleanPool ()
    {
        foreach (var objs in _pool)
        {
            //remove all null objects
            objs.Value.RemoveAll(obj => obj == null);
        }

        var newPool = new Dictionary<string, List<GameObject>>();
        foreach (var entry in _pool.Where(pool => pool.Value.Count != 0))
        {
            newPool.Add(entry.Key, entry.Value);
        }

        _pool = newPool;
    }

    /// <summary>
    /// refresh the objects in the pool.
    /// </summary>
    /// <param name="path"></param>
    /// <param name="includeSceneObjects"></param>
    public void Refresh (bool includeSceneObjects, string[] paths = null)
    {
        //remove pool with 0 objects
        CleanPool();

        if (paths != null)
        {
            foreach (var path in paths)
            {
                if (path.Equals("") == false)
                {
                    var resources = Resources.LoadAll<GameObject>(path);
                    AddToPool(resources);
                }
            }
        }

        if (includeSceneObjects)
        {
            var sceneObjs = UnityEngine.Object.FindObjectsOfType<GameObject>();
            AddToPool(sceneObjs);
        }
    }

    public void Clear ()
    {
        foreach (var key in _pool)
        {
            foreach (var obj in key.Value)
            {
                GameObject.Destroy(obj);
            }
        }
        _pool = new Dictionary<string, List<GameObject>>();
    }

    static void AddToPool (GameObject[] objs)
    {
        objs = objs.Where(obj => obj.GetComponent<IView>() != null).ToArray();
        foreach (var obj in objs)
        {
            if (_pool.ContainsKey(obj.name) == false)
            {
                var list = new List<GameObject>();
                obj.SetActive(false);
                list.Add(obj);
                _pool.Add(obj.name, list);
            }
            else
            {
                _pool[obj.name].Add(obj);
            }

            //obj.hideFlags = HideFlags.HideInHierarchy;
        }
    }

}

