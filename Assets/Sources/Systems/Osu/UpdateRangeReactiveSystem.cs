using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class UpdateRangeReactiveSystem : ReactiveSystem<GameEntity>
{
    public UpdateRangeReactiveSystem (Contexts contexts) : base(contexts.game)
    {
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collector
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.CurrentRange, GameMatcher.Timer));
    }

    protected override bool Filter (GameEntity entity)
    {
        // check for required components
        return entity.hasCurrentRange &&
            entity.hasDuration &&
            entity.hasTimer;
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            //calculate current range based on duration and timer current value
            e.ReplaceCurrentRange(Mathf.Clamp(e.timer.current / e.duration.value, 0f, 1f));
        }
    }
}