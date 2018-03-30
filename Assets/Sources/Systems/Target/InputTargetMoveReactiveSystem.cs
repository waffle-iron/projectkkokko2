using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class InputTargetMoveReactiveSystem : ReactiveSystem<InputEntity>
{
    private readonly GameContext _game;
    private readonly InputContext _input;
    private readonly CommandContext _cmd;

    public InputTargetMoveReactiveSystem (Contexts contexts) : base(contexts.input)
    {
        _input = contexts.input;
        _game = contexts.game;
        _cmd = contexts.command;
    }

    protected override ICollector<InputEntity> GetTrigger (IContext<InputEntity> context)
    {
        //return collector
        return context.CreateCollector(InputMatcher.AllOf(InputMatcher.TargetEntityID, InputMatcher.TargetMove));
    }

    protected override bool Filter (InputEntity entity)
    {
        // check for required components
        return entity.hasTargetEntityID && entity.hasTargetMove;
    }

    protected override void Execute (List<InputEntity> entities)
    {
        foreach (var e in entities)
        {
            var target = _game.GetEntityWithID(e.targetEntityID.value);
            
            if (target != null && target.hasMoveable)
            {
                var cmd = _cmd.CreateEntity();
                cmd.AddTargetEntityID(e.targetEntityID.value);
                cmd.AddTargetMove(e.targetMove.position, e.targetMove.stopDistance);
            }
        }
    }
}