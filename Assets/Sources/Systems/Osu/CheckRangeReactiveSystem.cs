using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class CheckRangeReactiveSystem : ReactiveSystem<GameEntity>
{
    public CheckRangeReactiveSystem (Contexts contexts) : base(contexts.game)
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
            entity.hasCurrentRange &&
            entity.hasAcceptableRange &&
            entity.hasHitRangeStatus == false;
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            // do stuff to the matched entities

            e.ReplaceHitRangeStatus(e.currentRange.value >= e.acceptableRange.values.x &&
            e.currentRange.value <= e.acceptableRange.values.y);

        }
    }
}