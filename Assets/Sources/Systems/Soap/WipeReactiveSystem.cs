using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class WipeReactiveSystem : ReactiveSystem<GameEntity>
{
    public WipeReactiveSystem (Contexts contexts) : base(contexts.game)
    {
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collector
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.TouchData, GameMatcher.Wipe));
    }

    protected override bool Filter (GameEntity entity)
    {
        // check for required components
        return entity.hasTouchData && entity.hasWipe;
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            
        }
    }
}