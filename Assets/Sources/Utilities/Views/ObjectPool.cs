using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool
{
    private List<GameObject> _objs;
    private GameObject _type;
    private readonly string _name;
    public string Name { get { return _name; } }
    public bool IsEmpty
    {
        get {
            return _objs.Count == 0;
        }
    }

    public ObjectPool (string name, GameObject type, int initInstances = 1)
    {
        _objs = new List<GameObject>();
        _name = name;
        _type = type;
        type.SetActive(false);
        _objs.Add(_type);

        //pool instances
        for (int ctr = 0; ctr < initInstances; ctr++)
        {
            var newObj = GameObject.Instantiate(_type, _type.transform.position, _type.transform.rotation, _type.transform.parent);
            newObj.name = name;
            newObj.SetActive(false);
            _objs.Add(newObj);
        }
    }

    public GameObject Get ()
    {
        foreach (var obj in _objs)
        {
            if (obj.activeSelf == false)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        //if pool is empty
        var newObj = GameObject.Instantiate(_type, _type.transform.position, _type.transform.rotation, _type.transform.parent);
        newObj.name = _type.name;
        newObj.SetActive(true);
        _objs.Add(newObj);
        return newObj;
    }

    public void Cleanup ()
    {
        _objs.RemoveAll(obj => obj == null);
    }
}

