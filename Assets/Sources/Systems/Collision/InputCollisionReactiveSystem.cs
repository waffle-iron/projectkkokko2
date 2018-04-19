using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class InputCollisionReactiveSystem : ReactiveSystem<InputEntity>
{
    private readonly GameContext _game;
    private readonly InputContext _input;
    private readonly CommandContext _cmd;

    public InputCollisionReactiveSystem (Contexts contexts) : base(contexts.input)
    {
        _input = contexts.input;
        _game = contexts.game;
        _cmd = contexts.command;
    }

    protected override ICollector<InputEntity> GetTrigger (IContext<InputEntity> context)
    {
        //return collector
        return context.CreateCollector(InputMatcher.AllOf(InputMatcher.TargetEntityID, InputMatcher.OnCollision));
    }

    protected override bool Filter (InputEntity entity)
    {
        // check for required components
        return entity.hasTargetEntityID && entity.hasOnCollision;
    }

    protected override void Execute (List<InputEntity> entities)
    {
        foreach (var e in entities)
        {
            // do stuff to the matched entities
            var target = _game.GetEntityWithID(e.targetEntityID.value);

            if (target != null && target.isCollidable)
            {
                var cmdEntity = _cmd.CreateEntity();
                cmdEntity.AddTargetEntityID(e.targetEntityID.value);
                cmdEntity.AddOnCollision(e.onCollision.data);
            }
        }
    }
}