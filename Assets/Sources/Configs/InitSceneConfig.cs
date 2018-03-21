using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InitSceneConfig : ScriptableObject
{
    [SceneName, SerializeField]
    private string scene;

    public string Scene
    {
        get { return scene; }
    }

    [SerializeField]
    private AssetBundleConfig[] bundles;

    public AssetBundleConfig[] Bundles
    {
        get {
            var newBundles = new AssetBundleConfig[bundles.Length];
            Array.Copy(bundles, newBundles, bundles.Length);
            return newBundles;
        }
    }

    [SerializeField]
    private InitEntityConfig[] entities;

    public InitEntityConfig[] Entities
    {
        get {
            var newEntities = new InitEntityConfig[entities.Length];
            Array.Copy(entities, newEntities, entities.Length);
            return newEntities;
        }
    }
}

