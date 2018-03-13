using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class CreateEntityInputReactiveSystem : ReactiveSystem<InputEntity>
{
    private readonly CommandContext _cmd;

    public CreateEntityInputReactiveSystem (Contexts contexts) : base(contexts.input)
    {
        _cmd = contexts.command;
    }

    protected override ICollector<InputEntity> GetTrigger (IContext<InputEntity> context)
    {
        //return collector
        return context.CreateCollector(InputMatcher.CreateEntity);
    }

    protected override bool Filter (InputEntity entity)
    {
        // check for required components
        return entity.hasCreateEntity;
    }

    protected override void Execute (List<InputEntity> entities)
    {
        foreach (var e in entities)
        {
            // do stuff to the matched entities
            var ety = _cmd.CreateEntity();
            ety.AddCreateEntity(ety.createEntity.id);
        }
    }
}