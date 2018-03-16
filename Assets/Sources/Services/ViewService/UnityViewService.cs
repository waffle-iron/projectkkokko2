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
            //this is in the pool
            if (objs.Count == 1)
            {
                var objTransform = objs[0].transform;
                newObj = GameObject.Instantiate(objTransform.gameObject, objTransform.position, objTransform.rotation, objTransform.parent);
            }
            else
            {
                //get the last copy
                newObj = objs[1];
                objs.RemoveAt(1);
            }
            newObj.name = name;
            newObj.hideFlags = HideFlags.None;
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
                newObj.hideFlags = HideFlags.None;
                newObj.name = name;
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
                view.instance.SetActive(true);
            }
        }
    }

    public static void Unload (IView views)
    {
        if (views != null)
        {
            views.instance.SetActive(false);
            AddToPool(new GameObject[] { views.instance });
        }
    }


    /// <summary>
    /// refresh the objects in the pool.
    /// </summary>
    /// <param name="path"></param>
    /// <param name="includeSceneObjects"></param>
    public void Refresh (bool includeSceneObjects, string[] paths = null)
    {
        foreach (var objs in _pool)
        {
            //remove all null objects
            objs.Value.RemoveAll(obj => obj == null);
        }

        //remove pool with 0 objects
        foreach (var entry in _pool.Where(pool => pool.Value.Count == 0))
        {
            _pool.Remove(entry.Key);
        }

        foreach (var path in paths)
        {
            if (path.Equals("") == false)
            {
                var resources = Resources.LoadAll<GameObject>(path);
                AddToPool(resources);
            }
        }

        if (includeSceneObjects)
        {
            var sceneObjs = UnityEngine.Object.FindObjectsOfType<GameObject>();
            AddToPool(sceneObjs);
        }
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

            obj.hideFlags = HideFlags.HideInHierarchy;
        }
    }

}

