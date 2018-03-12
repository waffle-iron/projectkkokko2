using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class CommandDebugReactiveSystem : ReactiveSystem<CommandEntity>
{
    private readonly MetaContext _meta;

    public CommandDebugReactiveSystem(Contexts contexts) : base(contexts.command)
    {
        _meta = contexts.meta;
    }

    protected override ICollector<CommandEntity> GetTrigger(IContext<CommandEntity> context)
    {
        //return collector
        return context.CreateCollector(CommandMatcher.Debug);
    }

    protected override bool Filter(CommandEntity entity)
    {
        // check for required components
        return entity.hasDebug;
    }

    protected override void Execute(List<CommandEntity> entities)
    {
        foreach (var e in entities)
        {
            _meta.debugService.instance.Log(e.debug.value);
        }
    }
}