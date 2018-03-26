using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

//[Entitas.CodeGenerator.SingleEntity]
[Game]
public sealed class SceneInitConfigComponent : IComponent
{
    [SceneName, PrimaryEntityIndex]
    public string sceneName;

    public AssetBundleConfig[] loadBundles;
    public AssetBundleConfig[] unloadBundles;
    public InitEntityConfig[] initEntities;
}