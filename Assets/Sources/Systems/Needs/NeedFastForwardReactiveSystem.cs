using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System;
using Entitas;

public class NeedFastForwardReactiveSystem : ReactiveSystem<GameEntity>
{
    private readonly MetaContext _meta;

    public NeedFastForwardReactiveSystem (Contexts contexts) : base(contexts.game)
    {
        _meta = contexts.meta;
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collector
        return context.CreateCollector(GameMatcher.AnyOf(GameMatcher.FastForward, GameMatcher.SuspendedTime));
    }

    protected override bool Filter (GameEntity entity)
    {
        // check for required components
        return entity.hasNeed &&
            entity.hasTrigger &&
            entity.hasTimer &&
            entity.hasSuspendedTime &&
            entity.isFastForward;
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            var elapsedSec = (int)DateTime.Now.Subtract(e.suspendedTime.current).TotalSeconds;

            _meta.debugService.instance.Log($"{DateTime.Now} - {e.suspendedTime.current} is {elapsedSec}");

            if (e.trigger.state == false && elapsedSec >= e.trigger.duration.GetInSeconds())
            {
                e.ReplaceTrigger(e.trigger.duration, true);
                elapsedSec -= (int)e.trigger.duration.GetInSeconds();
            }

            e.ReplaceTimer(e.timer.current + elapsedSec);

            e.isFastForward = false;

            _meta.debugService.instance.Log($" {e.need.type} fast forward by {elapsedSec}");
        }
    }
}