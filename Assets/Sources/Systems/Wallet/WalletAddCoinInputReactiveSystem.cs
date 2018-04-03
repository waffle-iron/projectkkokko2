using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class WalletAddCoinInputReactiveSystem : ReactiveSystem<InputEntity>
{
    private readonly GameContext _game;
    private readonly InputContext _input;
    private readonly CommandContext _cmd;

    public WalletAddCoinInputReactiveSystem (Contexts contexts) : base(contexts.input)
    {
        _input = contexts.input;
        _game = contexts.game;
        _cmd = contexts.command;
    }

    protected override ICollector<InputEntity> GetTrigger (IContext<InputEntity> context)
    {
        //return collector
        return context.CreateCollector(InputMatcher.AllOf(InputMatcher.TargetEntityID, InputMatcher.Coin));
    }

    protected override bool Filter (InputEntity entity)
    {
        // check for required components
        return entity.hasTargetEntityID && entity.hasCoin;
    }

    protected override void Execute (List<InputEntity> entities)
    {
        foreach (var e in entities)
        {
            // do stuff to the matched entities
            var target = _game.GetEntityWithID(e.targetEntityID.value);

            if (target != null && target.hasWallet)
            {
                var cmdEty = _cmd.CreateEntity();
                cmdEty.AddTargetEntityID(e.targetEntityID.value);
                cmdEty.AddCoin(e.coin.value, e.coin.type);
            }
        }
    }
}