using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class TargetPositionInputReactiveSystem : ReactiveSystem<InputEntity>
{
    private readonly GameContext _game;
    private readonly InputContext _input;
    private readonly CommandContext _cmd;

    public TargetPositionInputReactiveSystem (Contexts contexts) : base(contexts.input)
    {
        _input = contexts.input;
        _game = contexts.game;
        _cmd = contexts.command;
    }

    protected override ICollector<InputEntity> GetTrigger (IContext<InputEntity> context)
    {
        //return collector
        return context.CreateCollector(InputMatcher.AllOf(InputMatcher.TargetEntityID, InputMatcher.TargetPosition));
    }

    protected override bool Filter (InputEntity entity)
    {
        // check for required components
        return entity.hasTargetEntityID && entity.hasTargetPosition;
    }

    protected override void Execute (List<InputEntity> entities)
    {
        foreach (var e in entities)
        {
            // do stuff to the matched entities
            var target = _game.GetEntityWithID(e.targetEntityID.value);

            if (target != null)
            {
                var cmdEty = _cmd.CreateEntity();
                cmdEty.AddTargetEntityID(e.targetEntityID.value);
                cmdEty.AddTargetPosition(e.targetPosition.value);
            }
        }
    }
}