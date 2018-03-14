using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class PurchaseInputReactiveSystem : ReactiveSystem<InputEntity>
{
    private readonly CommandContext _cmd;
    private readonly GameContext _game;

    public PurchaseInputReactiveSystem (Contexts contexts) : base(contexts.input)
    {
        _cmd = contexts.command;
        _game = contexts.game;
    }

    protected override ICollector<InputEntity> GetTrigger (IContext<InputEntity> context)
    {
        //return 
        return context.CreateCollector(InputMatcher.AllOf(InputMatcher.TargetEntityID, InputMatcher.Purchased));
    }

    protected override bool Filter (InputEntity entity)
    {
        // check for required components
        return entity.hasTargetEntityID && entity.isPurchased;
    }

    protected override void Execute (List<InputEntity> entities)
    {
        foreach (var e in entities)
        {
            var target = _game.GetEntityWithID(e.targetEntityID.value);

            if (target != null)
            {
                var cmdEntity = _cmd.CreateEntity();
                cmdEntity.AddTargetEntityID(e.targetEntityID.value);

                if (target.hasPrice && target.isPrePurchase)
                {
                    //create a purchase command
                    cmdEntity.isPurchased = true;
                }
                else
                {
                    //create a pre purchase command
                    cmdEntity.isPrePurchase = true;
                }
            }
        }
    }
}