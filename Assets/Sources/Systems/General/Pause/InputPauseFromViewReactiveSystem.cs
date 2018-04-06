using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class InputPauseFromViewReactiveSystem : ReactiveSystem<InputEntity>
{
    private readonly GameContext _game;
    private readonly InputContext _input;
    private readonly CommandContext _cmd;

    public InputPauseFromViewReactiveSystem (Contexts contexts) : base(contexts.input)
    {
        _input = contexts.input;
        _game = contexts.game;
        _cmd = contexts.command;
    }

    protected override ICollector<InputEntity> GetTrigger (IContext<InputEntity> context)
    {
        //return collector
        return context.CreateCollector(InputMatcher.AllOf(InputMatcher.Pause));
    }

    protected override bool Filter (InputEntity entity)
    {
        // check for required components
        return entity.hasPause;
    }

    protected override void Execute (List<InputEntity> entities)
    {
        foreach (var e in entities)
        {
            // do stuff to the matched entities
            var target = _game.pauseEntity;

            if (target != null)
            {
                var cmdEty = _cmd.CreateEntity();
                cmdEty.AddPause(e.pause.state);

            }
        }
    }
}