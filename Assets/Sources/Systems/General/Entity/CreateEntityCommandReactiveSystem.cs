using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class CreateEntityCommandReactiveSystem : ReactiveSystem<CommandEntity>
{
    private readonly MetaContext _meta;

    public CreateEntityCommandReactiveSystem (Contexts contexts) : base(contexts.command)
    {
        _meta = contexts.meta;
    }

    protected override ICollector<CommandEntity> GetTrigger (IContext<CommandEntity> context)
    {
        //return collector
        return context.CreateCollector(CommandMatcher.CreateEntity);
    }

    protected override bool Filter (CommandEntity entity)
    {
        // check for required components
        return entity.hasCreateEntity;
    }

    protected override void Execute (List<CommandEntity> entities)
    {
        foreach (var e in entities)
        {
            // do stuff to the matched entities
            IEntity newEntity;
            _meta.entityService.instance.Get(e.createEntity.id, out newEntity);
        }
    }
}