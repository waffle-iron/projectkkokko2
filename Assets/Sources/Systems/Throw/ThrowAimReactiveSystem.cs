using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class ThrowAimReactiveSystem : ReactiveSystem<GameEntity>
{

    public ThrowAimReactiveSystem (Contexts contexts) : base(contexts.game)
    {
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collector
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.TouchData));
    }

    protected override bool Filter (GameEntity entity)
    {
        // check for required components
        return entity.hasTouchData && 
            entity.touchData.current.Phase == TouchPhase.Began &&
            entity.hasCanThrow &&
            entity.canThrow.isEnabled;
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            // do stuff to the matched entities
            e.ReplaceOrigin(e.touchData.current.WorldPosition);
        }
    }
}