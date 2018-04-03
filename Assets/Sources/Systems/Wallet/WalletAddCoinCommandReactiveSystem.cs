using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class WalletAddCoinCommandReactiveSystem : ReactiveSystem<CommandEntity>
{
    private readonly GameContext _game;

    public WalletAddCoinCommandReactiveSystem (Contexts contexts) : base(contexts.command)
    {
        _game = contexts.game;
    }

    protected override ICollector<CommandEntity> GetTrigger (IContext<CommandEntity> context)
    {
        //return collector
        return context.CreateCollector(CommandMatcher.AllOf(CommandMatcher.TargetEntityID, CommandMatcher.Coin));
    }

    protected override bool Filter (CommandEntity entity)
    {
        // check for required components
        return entity.hasTargetEntityID && entity.hasCoin;
    }

    protected override void Execute (List<CommandEntity> entities)
    {
        foreach (var e in entities)
        {
            // do stuff to the matched entities
            var target = _game.GetEntityWithID(e.targetEntityID.value);

            switch (e.coin.type)
            {
                case OperationType.ADD:
                    target.ReplaceWallet(target.wallet.amount + e.coin.value);
                    break;
                case OperationType.REDUCE:
                    target.ReplaceWallet(target.wallet.amount - e.coin.value);
                    break;
                case OperationType.REPLACE:
                    target.ReplaceWallet(e.coin.value);
                    break;
            }
        }
    }
}