using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class InputPauseReactiveSystem : ReactiveSystem<InputEntity>
{
    private readonly CommandContext _command;

    public InputPauseReactiveSystem (Contexts contexts) : base(contexts.input)
    {
        _command = contexts.command;
    }

    protected override ICollector<InputEntity> GetTrigger (IContext<InputEntity> context)
    {
        //return collector
        return context.CreateCollector(InputMatcher.Pause);
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
            _command.CreateEntity().AddPause(e.pause.state);
        }
    }
}