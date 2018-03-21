using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine;
using Entitas;

public class CreateEntitiesOnLoadSceneCompleteReactiveSystem : ReactiveSystem<GameEntity>
{
    private readonly MetaContext _meta;
    private readonly GameContext _game;
    private readonly InputContext _input;

    public CreateEntitiesOnLoadSceneCompleteReactiveSystem (Contexts contexts) : base(contexts.game)
    {
        _meta = contexts.meta;
        _game = contexts.game;
        _input = contexts.input;
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collector
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.LoadedViewsComplete, GameMatcher.LoadSceneComplete));
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
            var config = _game.GetEntityWithSceneInitConfig(_meta.loadSceneService.instance.ActiveScene);

            if (config == null) { Debug.LogError($"no config for scene {_meta.loadSceneService.instance.ActiveScene}"); }

            foreach (var entityCfg in config.sceneInitConfig.initEntities.SelectMany(init => init.Entities).ToArray())
            {
                var inputEntity = _input.CreateEntity();
                inputEntity.AddCreateEntity(entityCfg.Name);
            }

            _game.isLoadEntitiesComplete = true;
        }
    }
}