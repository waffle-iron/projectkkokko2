using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class WalletOverallAddCoindInputReactiveSystem : ReactiveSystem<InputEntity>
{
    private readonly GameContext _game;
    private readonly InputContext _input;
    private readonly CommandContext _cmd;
    private readonly IGroup<GameEntity> _wallets;

    public WalletOverallAddCoindInputReactiveSystem (Contexts contexts) : base(contexts.input)
    {
        _input = contexts.input;
        _game = contexts.game;
        _cmd = contexts.command;
        _wallets = _game.GetGroup(GameMatcher.Wallet);
    }

    protected override ICollector<InputEntity> GetTrigger (IContext<InputEntity> context)
    {
        //return collector
        return context.CreateCollector(InputMatcher.AllOf(InputMatcher.Coin).NoneOf(InputMatcher.TargetEntityID));
    }

    protected override bool Filter (InputEntity entity)
    {
        // check for required components
        return entity.hasCoin;
    }

    protected override void Execute (List<InputEntity> entities)
    {
        foreach (var e in entities)
        {
            // do stuff to the matched entities
            foreach (var target in _wallets.GetEntities())
            {
                var cmdEty = _cmd.CreateEntity();
                cmdEty.AddTargetEntityID(e.targetEntityID.value);
                cmdEty.AddCoin(e.coin.value, e.coin.type);
            }
        }
    }
}