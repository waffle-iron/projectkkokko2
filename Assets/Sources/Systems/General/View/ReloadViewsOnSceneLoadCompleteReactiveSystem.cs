using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine;
using Entitas;
using UniRx;

/// <summary>
/// reloads asset bundles and cleans views
/// </summary>
public class ReloadViewsOnSceneLoadCompleteReactiveSystem : ReactiveSystem<GameEntity>
{
    private readonly MetaContext _meta;
    private readonly GameContext _game;

    public ReloadViewsOnSceneLoadCompleteReactiveSystem (Contexts contexts) : base(contexts.game)
    {
        _meta = contexts.meta;
        _game = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collector
        return context.CreateCollector(GameMatcher.LoadSceneComplete);
    }

    protected override bool Filter (GameEntity entity)
    {
        // check for required components
        return true;
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            //clean
            _meta.viewService.instance.Clean();
            var debug = _meta.debugService.instance;
            //reload
            var config = _game.GetEntityWithSceneInitConfig(_meta.loadSceneService.instance.ActiveScene);

            if (config == null) { debug.LogError($"no config for scene {_meta.loadSceneService.instance.ActiveScene}"); }

            foreach (var unload in config.sceneInitConfig.unloadBundles.SelectMany(bundle => bundle.Names))
            {
                _meta.viewService.instance.Unload(unload);
            }

            _meta.viewService.instance.Populate(
                true,
                config.sceneInitConfig.loadBundles.SelectMany(bundle => bundle.Names).ToArray())
                //.Do(result => Debug.Log($"view service status: {result}"))
                .Where(result => result == true)
                .Subscribe(_ => { debug.Log("load views complete"); _game.isLoadedViewsComplete = true; });
        }
    }
}