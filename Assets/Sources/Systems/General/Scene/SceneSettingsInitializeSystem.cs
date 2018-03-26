using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class SceneSettingsInitializeSystem : IInitializeSystem
{
    private readonly GameContext _game;
    private readonly MetaContext _meta;

    public SceneSettingsInitializeSystem (Contexts contexts)
    {
        _game = contexts.game;
        _meta = contexts.meta;
    }

    public void Initialize ()
    {
        // Initialization code here
        var configs = _meta.sceneSettingService.instance.GetAll();

        foreach (var config in configs)
        {
            var configEntity = _game.CreateEntity();
            configEntity.AddSceneInitConfig(config.Scene, config.LoadBundles, config.UnloadBundles, config.Entities);
            configEntity.isDoNotDestroyOnSceneChange = true;
        }
    }
}