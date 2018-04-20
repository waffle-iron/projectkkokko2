using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class CommandCollisionReactiveSystem : ReactiveSystem<CommandEntity>
{
    private readonly GameContext _game;

    public CommandCollisionReactiveSystem (Contexts contexts) : base(contexts.command)
    {
        _game = contexts.game;
    }

    protected override ICollector<CommandEntity> GetTrigger (IContext<CommandEntity> context)
    {
        //return collector
        return context.CreateCollector(CommandMatcher.AllOf(CommandMatcher.TargetEntityID, CommandMatcher.OnCollision));
    }

    protected override bool Filter (CommandEntity entity)
    {
        // check for required components
        return entity.hasTargetEntityID && entity.hasOnCollision;
    }

    protected override void Execute (List<CommandEntity> entities)
    {
        foreach (var e in entities)
        {
            var target = _game.GetEntityWithID(e.targetEntityID.value);

            //var updatedCollisions = target.hasOnCollision ? new List<CollisionData>() : target.onCollision.data;

            //updatedCollisions.RemoveAll(col => col.Type == CollisionType.EXIT);
            //updatedCollisions.AddRange(target.onCollision.data);

            target.ReplaceOnCollision(e.onCollision.data);
        }
    }
}