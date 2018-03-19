using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

/// <summary>
/// clean view pools when a scene has finished loading
/// </summary>
public class CleanViewsReactiveSystem : ReactiveSystem<GameEntity>
{
    private readonly MetaContext _meta;

    public CleanViewsReactiveSystem (Contexts contexts) : base(contexts.game)
    {
        _meta = contexts.meta;
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
            _meta.viewService.instance.Clean();
        }
    }
}