using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class NeedTriggerReactiveSystem : ReactiveSystem<GameEntity>
{
    private readonly InputContext _input;

    public NeedTriggerReactiveSystem (Contexts contexts) : base(contexts.game)
    {
        _input = contexts.input;
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collector
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Need, GameMatcher.Timer));
    }

    protected override bool Filter (GameEntity entity)
    {
        // check for required components
        return
            entity.hasTrigger && 
            entity.trigger.state == false &&
            entity.timer.current >= entity.trigger.duration.GetInSeconds();
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            e.ReplaceTrigger(e.trigger.duration, true);

            var inputEntity = _input.CreateEntity();
            inputEntity.AddTargetEntityID(e.iD.value);
            inputEntity.isTimerReset = true;
        }
    }
}