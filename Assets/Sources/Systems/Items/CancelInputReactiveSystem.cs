using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class CancelInputReactiveSystem : ReactiveSystem<InputEntity>
{
    private readonly GameContext _game;
    private readonly CommandContext _cmd;

    public CancelInputReactiveSystem (Contexts contexts) : base(contexts.input)
    {
        _game = contexts.game;
        _cmd = contexts.command;
    }

    protected override ICollector<InputEntity> GetTrigger (IContext<InputEntity> context)
    {
        //return collector
        return context.CreateCollector(InputMatcher.AllOf(InputMatcher.TargetEntityID, InputMatcher.Cancel));
    }

    protected override bool Filter (InputEntity entity)
    {
        // check for required components
        return entity.hasTargetEntityID && entity.isCancel;
    }

    protected override void Execute (List<InputEntity> entities)
    {
        foreach (var e in entities)
        {
            var target = _game.GetEntityWithID(e.targetEntityID.value);
            if (target != null && target.isPrePurchase)
            {
                var cmdEntity = _cmd.CreateEntity();
                cmdEntity.AddTargetEntityID(e.targetEntityID.value);
                cmdEntity.isCancel = true;
            }
        }
    }
}