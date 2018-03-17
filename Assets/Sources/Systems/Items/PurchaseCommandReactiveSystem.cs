﻿using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class PurchaseCommandReactiveSystem : ReactiveSystem<CommandEntity>
{
    private readonly GameContext _game;
    private readonly InputContext _input;

    public PurchaseCommandReactiveSystem (Contexts contexts) : base(contexts.command)
    {
        _game = contexts.game;
        _input = contexts.input;
    }

    protected override ICollector<CommandEntity> GetTrigger (IContext<CommandEntity> context)
    {
        //return collector
        return context.CreateCollector(CommandMatcher.AllOf(CommandMatcher.TargetEntityID, CommandMatcher.Purchased));
    }

    protected override bool Filter (CommandEntity entity)
    {
        // check for required components
        return entity.hasTargetEntityID && entity.isPurchased;
    }

    protected override void Execute (List<CommandEntity> entities)
    {
        foreach (var e in entities)
        {

            var target = _game.GetEntityWithID(e.targetEntityID.value);
            target.isPrePurchase = false;
            target.isPurchased = true;

            _game.ReplaceWallet(_game.wallet.amount - target.price.amount);

            var saveWalletEntity = _input.CreateEntity();
            saveWalletEntity.AddTargetEntityID(_game.walletEntity.iD.value);
            saveWalletEntity.isSave = true;

            var saveItemEntity = _input.CreateEntity();
            saveItemEntity.AddTargetEntityID(target.iD.value);
            saveItemEntity.isSave = true;

            var equipInputEntity = _input.CreateEntity();
            equipInputEntity.AddTargetEntityID(target.iD.value);
            equipInputEntity.isEquipped = true;
        }
    }
}