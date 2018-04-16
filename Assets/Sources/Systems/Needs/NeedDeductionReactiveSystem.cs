using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class NeedDeductionReactiveSystem : ReactiveSystem<GameEntity>
{
    private readonly MetaContext _meta;

    public NeedDeductionReactiveSystem (Contexts contexts) : base(contexts.game)
    {
        _meta = contexts.meta;
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
            entity.hasInterval &&
            entity.timer.current >= entity.interval.duration.GetInSeconds();
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            uint count = 0;
            if (e.hasDeductions) { count += e.deductions.count; }
            _meta.debugService.instance.Log($"{e.need.type} prev deductions of {count}");
            count += (uint)Mathf.FloorToInt((e.timer.current / e.interval.duration.GetInSeconds()));
            _meta.debugService.instance.Log($"{e.need.type} current timer of {e.timer.current} divided by {e.interval.duration.GetInSeconds()}");
            e.ReplaceDeductions(count);
            _meta.debugService.instance.Log($"{e.need.type} will deduct {e.deductions.count}");
        }
    }
}