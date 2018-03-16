using System;
using System.Collections.Generic;
using Entitas;
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

    protected override void RegisterListeners (IEntity entity, IContext context)
    {
        var gameEntity = (GameEntity)entity;
        gameEntity.AddGameWalletListener(this);
    }

    protected override void UnregisterListeners (IEntity entity, IContext context)
    {
        var gameEntity = (GameEntity)entity;
        gameEntity.RemoveGameWalletListener(this);
    }
}

