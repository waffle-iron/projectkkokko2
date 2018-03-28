using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class CommandMoveReactiveSystem : ReactiveSystem<CommandEntity>
{
    private readonly GameContext _game;

    public CommandMoveReactiveSystem (Contexts contexts) : base(contexts.command)
    {
        _game = contexts.game;
    }

    protected override ICollector<CommandEntity> GetTrigger (IContext<CommandEntity> context)
    {
        //return collector
        return context.CreateCollector(CommandMatcher.AllOf(CommandMatcher.TargetEntityID, CommandMatcher.Position));
    }

    protected override bool Filter (CommandEntity entity)
    {
        // check for required components
        return entity.hasTargetEntityID && entity.hasPosition;
    }

    protected override void Execute (List<CommandEntity> entities)
    {
        foreach (var e in entities)
        {
            var target = _game.GetEntityWithID(e.targetEntityID.value);

            target.isMoving = true;
            target.ReplacePosition(e.position.current);
        }
    }
}