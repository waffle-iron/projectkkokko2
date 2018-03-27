using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class CommandTargetMoveReactiveSystem : ReactiveSystem<CommandEntity>
{
    private readonly GameContext _game;

    public CommandTargetMoveReactiveSystem (Contexts contexts) : base(contexts.command)
    {
        _game = contexts.game;
    }

    protected override ICollector<CommandEntity> GetTrigger (IContext<CommandEntity> context)
    {
        //return collector
        return context.CreateCollector(CommandMatcher.AllOf(CommandMatcher.TargetEntityID, CommandMatcher.TargetMove));
    }

    protected override bool Filter (CommandEntity entity)
    {
        // check for required components
        return entity.hasTargetEntityID && entity.hasTargetMove;
    }

    protected override void Execute (List<CommandEntity> entities)
    {
        foreach (var e in entities)
        {
            var target = _game.GetEntityWithID(e.targetEntityID.value);
            target.ReplaceTargetMove(e.targetMove.position);
        }
    }
}