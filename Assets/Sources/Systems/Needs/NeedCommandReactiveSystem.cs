using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class NeedCommandReactiveSystem : ReactiveSystem<CommandEntity>
{
    private readonly GameContext _game;
    private readonly InputContext _input;

    public NeedCommandReactiveSystem (Contexts contexts) : base(contexts.command)
    {
        _game = contexts.game;
        _input = contexts.input;
    }

    protected override ICollector<CommandEntity> GetTrigger (IContext<CommandEntity> context)
    {
        //return collector
        return context.CreateCollector(CommandMatcher.AllOf(CommandMatcher.TargetNeed, CommandMatcher.Reset));
    }

    protected override bool Filter (CommandEntity entity)
    {
        // check for required components
        return entity.hasTargetNeed && entity.hasReset;
    }

    protected override void Execute (List<CommandEntity> entities)
    {
        foreach (var e in entities)
        {
            var target = _game.GetEntityWithNeed(e.targetNeed.type);
            var targetOfTarget = _game.GetEntityWithNeed(target.targetNeed.type);

            //reset triggered need and timer
            target.ReplaceTrigger(target.trigger.duration, false);

            if (e.hasFood)
            {
                Debug.Log($"reduced timer {target.timer.current} by {(target.trigger.duration.GetInSeconds() * e.food.recovery)} ");
                target.ReplaceTimer(target.timer.current - (target.trigger.duration.GetInSeconds() * e.food.recovery));
                Debug.Log($"current timer {target.timer.current} ");
            }
            else
            {
                var input = _input.CreateEntity();
                input.AddTargetEntityID(target.iD.value);
                input.isTimerReset = true;
            }

            //increase value of the targeted need of the triggered need
            var newValue = targetOfTarget.current.amount + e.reset.restoreAmount;
            newValue = Mathf.Clamp(newValue, 0, targetOfTarget.max.amount);
            targetOfTarget.ReplaceCurrent(newValue);
        }
    }
}