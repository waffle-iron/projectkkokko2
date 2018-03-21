using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine;
using Entitas;

public class CreateEntitiesOnLoadSceneCompleteReactiveSystem : IExecuteSystem
{
    private readonly MetaContext _meta;
    private readonly GameContext _game;
    private readonly InputContext _input;
    private readonly Contexts _contexts;

    public CreateEntitiesOnLoadSceneCompleteReactiveSystem (Contexts contexts)
    {
        _meta = contexts.meta;
        _game = contexts.game;
        _input = contexts.input;
        _contexts = contexts;
    }

    public void Execute ()
    {
        if (_game.isLoadSceneComplete && _game.isLoadedViewsComplete && _game.isLoadEntitiesComplete == false)
        {
            var config = _game.GetEntityWithSceneInitConfig(_meta.loadSceneService.instance.ActiveScene);

            if (config == null) { Debug.LogError($"no config for scene {_meta.loadSceneService.instance.ActiveScene}"); }

            foreach (var entityCfg in config.sceneInitConfig.initEntities.SelectMany(init => init.Entities).ToArray())
            {
                entityCfg.Create(_contexts);
            }
            Debug.Log("load entities complete");
            _game.isLoadEntitiesComplete = true;
        }
    }
}