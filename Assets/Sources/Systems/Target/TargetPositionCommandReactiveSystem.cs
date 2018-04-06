using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class TargetPositionCommandReactiveSystem : ReactiveSystem<CommandEntity>
{
    private readonly GameContext _game;

    public TargetPositionCommandReactiveSystem (Contexts contexts) : base(contexts.command)
    {
        _game = contexts.game;
    }

    protected override ICollector<CommandEntity> GetTrigger (IContext<CommandEntity> context)
    {
        //return collector
        return context.CreateCollector(CommandMatcher.AllOf(CommandMatcher.TargetEntityID, CommandMatcher.TargetPosition));
    }

    protected override bool Filter (CommandEntity entity)
    {
        // check for required components
        return entity.hasTargetEntityID && entity.hasTargetPosition;
    }

    protected override void Execute (List<CommandEntity> entities)
    {
        foreach (var e in entities)
        {
            // do stuff to the matched entities
            var target = _game.GetEntityWithID(e.targetEntityID.value);
            target.ReplaceTargetPosition(e.targetPosition.value);
        }
    }
}