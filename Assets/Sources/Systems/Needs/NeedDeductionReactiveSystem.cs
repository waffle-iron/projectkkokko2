using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class NeedDeductionReactiveSystem : ReactiveSystem<GameEntity>
{
    public NeedDeductionReactiveSystem (Contexts contexts) : base(contexts.game)
    {
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collector
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Timer, GameMatcher.Need));
    }

    protected override bool Filter (GameEntity entity)
    {
        // check for required components
        return entity.hasNeed &&
            entity.hasTimer &&
            entity.hasTrigger &&
            entity.trigger.state == true &&
            entity.hasInterval;
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            uint count = 0;
            if (e.hasDeductions) { count += e.deductions.count; }
            count += (uint)(e.timer.current / e.interval.duration.GetInSeconds());
            e.ReplaceDeductions(count);
        }
    }
}