using System;
using System.Collections.Generic;
using System.Linq;
using Entitas;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class NeedView : View, IGameCurrentListener
{
    [SerializeField]
    private Text text;

    public void OnCurrent (GameEntity entity, int amount)
    {
        text.text = amount.ToString();
    }

    protected override void OnEnable ()
    {
        base.OnEnable();
    }

    protected override IObservable<bool> Initialize ()
    {
        return Observable.Return(true);
    }

    protected override void RegisterListeners (IEntity entity, IContext context)
    {
        var gameEntity = (GameEntity)entity;
        gameEntity.AddGameCurrentListener(this);
    }

    protected override void UnregisterListeners (IEntity entity, IContext context)
    {
        var gameEntity = (GameEntity)entity;
        gameEntity.RemoveGameCurrentListener(this);
    }
}

