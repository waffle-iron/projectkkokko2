using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class NeedDeductReactiveSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _game;
    private readonly InputContext _input;

    public NeedDeductReactiveSystem (Contexts contexts) : base(contexts.game)
    {
        _game = contexts.game;
        _input = contexts.input;
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collector
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Need, GameMatcher.TargetNeed, GameMatcher.Trigger, GameMatcher.Timer));
    }

    protected override bool Filter (GameEntity entity)
    {
        // check for required components
        return  entity.hasTrigger &&
                entity.trigger.state == true &&
                entity.hasInterval &&
                entity.hasDeplete &&
                entity.hasTimerState &&
                entity.timerState.isRunning &&
                entity.timer.current >= entity.interval.duration.GetInSeconds();
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            //get target need
            var target = _game.GetEntityWithNeed(e.targetNeed.type);

            if (target != null && (target.hasCurrent && target.hasMax))
            {
                //check for current
                //deduct and clamp
                var newValue = target.current.amount - e.deplete.amount;
                newValue = Mathf.Clamp(newValue, 0, target.max.amount);
                target.ReplaceCurrent(newValue);

                //reset timer
                var inputEntity = _input.CreateEntity();
                inputEntity.AddTargetEntityID(e.iD.value);
                inputEntity.isTimerReset = true;
            }
        }
    }
}