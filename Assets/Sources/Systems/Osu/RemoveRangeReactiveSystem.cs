using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class RemoveRangeReactiveSystem : ReactiveSystem<GameEntity>
{
    public RemoveRangeReactiveSystem (Contexts contexts) : base(contexts.game)
    {
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collector
        return context.CreateCollector(GameMatcher.CurrentRange);
    }

    protected override bool Filter (GameEntity entity)
    {
        // check for required components
        return entity.hasCurrentRange;
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            // do stuff to the matched entities
            if (e.currentRange.value == 1.0f)
            {
                e.isToDestroy = true;
            }
        }
    }
}