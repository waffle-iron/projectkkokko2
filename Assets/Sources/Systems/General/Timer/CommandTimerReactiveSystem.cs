using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class CommandTimerReactiveSystem : ReactiveSystem<CommandEntity>
{
    private readonly GameContext _game;

    public CommandTimerReactiveSystem (Contexts contexts) : base(contexts.command)
    {
        _game = contexts.game;
    }

    protected override ICollector<CommandEntity> GetTrigger (IContext<CommandEntity> context)
    {
        //return collector
        return context.CreateCollector(CommandMatcher.AllOf(CommandMatcher.TargetEntityID).AnyOf(CommandMatcher.TimerState, CommandMatcher.TimerReset));
    }

    protected override bool Filter (CommandEntity entity)
    {
        // check for required components
        return entity.hasTargetEntityID;
    }

    protected override void Execute (List<CommandEntity> entities)
    {
        foreach (var e in entities)
        {
            var target = _game.GetEntityWithID(e.targetEntityID.value);
            if (e.hasTimerState)
            {
                target.ReplaceTimerState(e.timerState.isRunning);
            }
            if (e.isTimerReset)
            {
                target.ReplaceTimer(0f);
            }
        }
    }
}