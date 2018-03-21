using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InitEntityConfig : ScriptableObject
{
    [SerializeField]
    private IEntityConfig[] entities;

    public IEntityConfig[] Entities
    {
        get {
            var newList = new IEntityConfig[entities.Length];
            Array.Copy(entities, newList, entities.Length);
            return newList;
        }
    }
}

