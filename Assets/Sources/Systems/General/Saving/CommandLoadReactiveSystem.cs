using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class CommandLoadReactiveSystem : ReactiveSystem<CommandEntity>
{
    private readonly GameContext _game;
    private readonly MetaContext _meta;
    private Contexts _contexts;

    public CommandLoadReactiveSystem (Contexts contexts) : base(contexts.command)
    {
        _game = contexts.game;
        _meta = contexts.meta;
        _contexts = contexts;
    }

    protected override ICollector<CommandEntity> GetTrigger (IContext<CommandEntity> context)
    {
        //return collector
        return context.CreateCollector(CommandMatcher.Load);
    }

    protected override bool Filter (CommandEntity entity)
    {
        // check for required components
        return entity.hasLoad;
    }

    protected override void Execute (List<CommandEntity> entities)
    {
        foreach (var e in entities)
        {
            // do stuff to the matched entities
            if (e.load.createNew)
            {
                _meta.saveService.instance.LoadNew(e.load.id, _contexts);
            }
        }
    }
}