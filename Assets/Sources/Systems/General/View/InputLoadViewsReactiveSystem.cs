using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class InputLoadViewsReactiveSystem : ReactiveSystem<InputEntity>
{
    private readonly CommandContext _cmd;

    public InputLoadViewsReactiveSystem (Contexts contexts) : base(contexts.input)
    {
        _cmd = contexts.command;
    }

    protected override ICollector<InputEntity> GetTrigger (IContext<InputEntity> context)
    {
        //return collector
        return context.CreateCollector(InputMatcher.LoadViews);
    }

    protected override bool Filter (InputEntity entity)
    {
        // check for required components
        return entity.hasLoadViews;
    }

    protected override void Execute (List<InputEntity> entities)
    {
        foreach (var e in entities)
        {
            // do stuff to the matched entities
            var cmdEntity = _cmd.CreateEntity();
            cmdEntity.AddLoadViews(e.loadViews.paths, e.loadViews.includeSceneObjects);
        }
    }
}