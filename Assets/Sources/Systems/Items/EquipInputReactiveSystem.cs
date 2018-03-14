using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class EquipInputReactiveSystem : ReactiveSystem<InputEntity>
{
    private readonly GameContext _game;
    private readonly CommandContext _cmd;

    public EquipInputReactiveSystem (Contexts contexts) : base(contexts.input)
    {
        _game = contexts.game;
        _cmd = contexts.command;
    }

    protected override ICollector<InputEntity> GetTrigger (IContext<InputEntity> context)
    {
        //return collector
        return context.CreateCollector(InputMatcher.AllOf(InputMatcher.TargetEntityID, InputMatcher.Equipped));
    }

    protected override bool Filter (InputEntity entity)
    {
        // check for required components
        return entity.isEquipped && entity.hasTargetEntityID;
    }

    protected override void Execute (List<InputEntity> entities)
    {
        foreach (var e in entities)
        {
            var target = _game.GetEntityWithID(e.targetEntityID.value);
            if (target != null && target.hasAccessory & target.isPurchased)
            {
                var cmdEntity = _cmd.CreateEntity();
                cmdEntity.AddTargetEntityID(e.targetEntityID.value);
                cmdEntity.isEquipped = true;
            }
        }
    }
}