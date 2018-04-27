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
    private Slider _slider;

    public void OnCurrent (GameEntity entity, int amount)
    {
        _slider.value = amount;
    }

    protected override void OnEnable ()
    {
        base.OnEnable();
    }

    protected override IObservable<bool> Initialize (IEntity entity, IContext context)
    {
        var gameety = (GameEntity)entity;

        if (gameety.hasMax) { _slider.maxValue = gameety.max.amount; }
        if (gameety.hasCurrent) { _slider.value = gameety.current.amount; }

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

