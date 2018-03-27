using System;
using System.Collections.Generic;
using Entitas;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class WalletView : View, IGameWalletListener
{
    [SerializeField]
    private Text _text;

    public void OnWallet (GameEntity entity, int amount)
    {
        _text.text = amount.ToString();
    }

    protected override void OnEnable ()
    {
        base.OnEnable();
    }

    protected override IObservable<bool> Initialize (IEntity entity, IContext context)
    {
        return Observable.Return(true);
    }

    protected override void RegisterListeners (IEntity entity, IContext context)
    {
        var gameEntity = (GameEntity)entity;
        gameEntity.AddGameWalletListener(this);
        if (gameEntity.hasWallet)
        {
            _text.text = gameEntity.wallet.amount.ToString();
        }
    }

    protected override void UnregisterListeners (IEntity entity, IContext context)
    {
        var gameEntity = (GameEntity)entity;
        gameEntity.RemoveGameWalletListener(this);
    }
}

