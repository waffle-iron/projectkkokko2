using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class InputTimerReactiveSystem : ReactiveSystem<InputEntity>
{
    private readonly GameContext _game;
    private readonly CommandContext _command;

    public InputTimerReactiveSystem (Contexts contexts) : base(contexts.input)
    {
        _game = contexts.game;
        _command = contexts.command;
    }

    protected override ICollector<InputEntity> GetTrigger (IContext<InputEntity> context)
    {
        //return collector
        return context.CreateCollector(InputMatcher.AllOf(InputMatcher.TargetEntityID).AnyOf(InputMatcher.TimerState, InputMatcher.TimerReset));
    }

    protected override bool Filter (InputEntity entity)
    {
        // check for required components
        return entity.hasTargetEntityID;
    }

    protected override void Execute (List<InputEntity> entities)
    {
        foreach (var e in entities)
        {
            var target = _game.GetEntityWithID(e.targetEntityID.value);
            if (target != null && target.hasTimer)
            {
                var cmd = _command.CreateEntity();
                cmd.AddTargetEntityID(e.targetEntityID.value);
                if (e.hasTimerState)
                {
                    cmd.AddTimerState(e.timerState.isRunning);
                }
                if (e.isTimerReset)
                {
                    cmd.isTimerReset = e.isTimerReset;
                }

            }
        }
    }
}