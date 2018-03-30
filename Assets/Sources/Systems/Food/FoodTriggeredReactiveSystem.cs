using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class FoodTriggeredReactiveSystem : ReactiveSystem<GameEntity>
{
    public FoodTriggeredReactiveSystem (Contexts contexts) : base(contexts.game)
    {
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collector
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Food, GameMatcher.Timer));
    }

    protected override bool Filter (GameEntity entity)
    {
        // check for required components
        return entity.hasFood &&
            entity.hasTrigger &&
            entity.trigger.state == false &&
            entity.hasTimer;
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            if (e.timer.current >= e.trigger.duration.GetInSeconds())
            {
                e.ReplaceTrigger(e.trigger.duration, true);
            }
        }
    }
}