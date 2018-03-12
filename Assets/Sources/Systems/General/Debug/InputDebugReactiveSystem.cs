using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class InputDebugReactiveSystem : ReactiveSystem<InputEntity>
{
    private readonly CommandContext _command;

    public InputDebugReactiveSystem(Contexts contexts) : base(contexts.input)
    {
        _command = contexts.command;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        //return collector
        return context.CreateCollector(InputMatcher.Debug);
    }

    protected override bool Filter(InputEntity entity)
    {
        // check for required components
        return entity.hasDebug;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        foreach (var e in entities)
        {
            // do stuff to the matched entities
            if (e.debug.Equals("") == false)
            {
                var entity = _command.CreateEntity();
                entity.AddDebug(e.debug.value);
            }
        }
    }
}