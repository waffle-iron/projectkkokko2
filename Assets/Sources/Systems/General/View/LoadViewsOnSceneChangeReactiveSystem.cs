using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine;
using Entitas;

public class LoadViewsOnSceneChangeReactiveSystem : ReactiveSystem<GameEntity>
{
    private readonly MetaContext _meta;
    private readonly GameContext _game;

    public LoadViewsOnSceneChangeReactiveSystem (Contexts contexts) : base(contexts.game)
    {
        _game = contexts.game;
        _meta = contexts.meta;
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collector
        return context.CreateCollector(GameMatcher.LoadScene.Added());
    }

    protected override bool Filter (GameEntity entity)
    {
        // check for required components
        return entity.hasLoadScene;
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            var config = _game.GetEntityWithSceneInitConfig(e.loadScene.name);
            if (config == null) { Debug.LogError($"no config for scene {e.loadScene.name}"); }
            else
            {
                foreach (var bundle in config.sceneInitConfig.loadBundles.SelectMany(bundle => bundle.Names))
                {
                    //view service using asset bundles
                }
            }
        }
    }
}