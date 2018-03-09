using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class UnityViewService : IViewService
{
    private readonly Contexts _contexts;
    private static Dictionary<string, List<GameObject>> _pool;

    public UnityViewService (Contexts contexts)
    {
        _contexts = contexts;
        //create game object pool
        _pool = new Dictionary<string, List<GameObject>>();
    }

    public void Load (IEntity entity, string name)
    {
        List<GameObject> objs = null;
        IView view = null;
        GameObject newObj = null;

        if (_pool.TryGetValue(name, out objs))
        {
            if (objs.Count == 1)
            {
                var objTransform = objs[0].transform;
                newObj = GameObject.Instantiate(objTransform.gameObject, objTransform.position, objTransform.rotation, objTransform.parent);
                newObj.name = name;
            }
            else
            {
                newObj = objs[0];
                objs.RemoveAt(0);
            }

            view = newObj.GetComponentInChildren<IView>();
        }
        else
        {
            var obj = Resources.Load<GameObject>(name);
            if (obj != null)
            {
                AddToPool(new GameObject[] { obj });
                newObj = GameObject.Instantiate(obj, obj.transform.position, obj.transform.rotation, obj.transform.parent);
                newObj.name = name;
                view = newObj.GetComponentInChildren<IView>();
            }
            else
            {
                Debug.LogWarning($"object {name} does not exist.");
            }
        }

        if (newObj!= null && view != null)
        {
            view.Link(entity, _contexts.game);
            view.Show();
        }
    }

    public static void Unload (IView view)
    {
        if (view != null)
        {
            view.Hide();
            view.instance.SetActive(false);
            _pool[view.instance.name].Add(view.instance);
        }
    }

    public void Refresh (string path, bool includeSceneObjects)
    {
        //refresh object pool
        foreach (var objs in _pool)
        {
            objs.Value.RemoveAll(obj => obj == null);
        }

        if (path.Equals("") == false)
        {
            var resources = Resources.LoadAll<GameObject>(path);
            AddToPool(resources);
        }

        if (includeSceneObjects)
        {
            var sceneObjs = UnityEngine.Object.FindObjectsOfType<GameObject>();
            AddToPool(sceneObjs);
        }
    }

    void AddToPool (GameObject[] objs)
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
        }
    }

}

