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
    private AssetBundleConfig[] loadBundles;

    public AssetBundleConfig[] LoadBundles
    {
        get {
            var newBundles = new AssetBundleConfig[loadBundles.Length];
            Array.Copy(loadBundles, newBundles, loadBundles.Length);
            return newBundles;
        }
    }

    [SerializeField]
    private AssetBundleConfig[] unloadBundles;

    public AssetBundleConfig[] UnloadBundles
    {
        get {
            var newBundles = new AssetBundleConfig[unloadBundles.Length];
            Array.Copy(unloadBundles, newBundles, unloadBundles.Length);
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

