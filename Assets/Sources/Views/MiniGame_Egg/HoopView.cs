using UnityEngine;
using System.Collections;
using Entitas;
using System;
using UniRx;
using UniRx.Triggers;

public class HoopView : View
{
    [SerializeField]
    private ColliderEnabler _enabler;

    protected override IObservable<bool> Initialize (IEntity entity, IContext context)
    {
        return Observable.Return(true);
    }

    protected override void RegisterListeners (IEntity entity, IContext context)
    {
        var gameEty = (GameEntity)entity;
    }

    protected override void UnregisterListeners (IEntity entity, IContext context)
    {
        var gameEty = (GameEntity)entity;
    }
}
