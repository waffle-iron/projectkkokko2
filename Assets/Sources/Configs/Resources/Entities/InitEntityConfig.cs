using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InitEntityConfig : ScriptableObject
{
    [SerializeField]
    private UnityEntityConfig[] entities;

    public UnityEntityConfig[] Entities
    {
        get {
            var newList = new UnityEntityConfig[entities.Length];
            Array.Copy(entities, newList, entities.Length);
            return newList;
        }
    }
}

