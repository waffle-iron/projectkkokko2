using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class InputMoveReactiveSystem : ReactiveSystem<InputEntity>
{
    private readonly GameContext _game;
    private readonly InputContext _input;
    private readonly CommandContext _cmd;

    public InputMoveReactiveSystem (Contexts contexts) : base(contexts.input)
    {
        _input = contexts.input;
        _game = contexts.game;
        _cmd = contexts.command;
    }

    protected override ICollector<InputEntity> GetTrigger (IContext<InputEntity> context)
    {
        //return collector
        return context.CreateCollector(InputMatcher.AllOf(InputMatcher.TargetEntityID, InputMatcher.Position));
    }

    protected override bool Filter (InputEntity entity)
    {
        // check for required components
        return entity.hasTargetEntityID && entity.hasPosition;
    }

    protected override void Execute (List<InputEntity> entities)
    {
        foreach (var e in entities)
        {
            var target = _game.GetEntityWithID(e.targetEntityID.value);

            if (target != null && target.hasMoveable)
            {
                if (target.hasPosition && target.position.current.magnitude == e.position.current.magnitude) { continue; }

                var commandEntity = _cmd.CreateEntity();
                commandEntity.AddTargetEntityID(e.targetEntityID.value);
                commandEntity.AddPosition(e.position.current);
                commandEntity.isTeleport = e.isTeleport;
            }
        }
    }
}