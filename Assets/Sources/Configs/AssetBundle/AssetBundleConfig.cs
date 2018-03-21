using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AssetBundleConfig : ScriptableObject
{
    [SerializeField]
    private string[] names;

    public string[] Names
    {
        get {
            var newNames = new string[names.Length];
            Array.Copy(names, newNames, names.Length);
            return newNames;
        }
    }
}
