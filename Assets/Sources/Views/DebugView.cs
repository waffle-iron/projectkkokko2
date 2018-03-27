using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Entitas;
using UniRx;

public class DebugView : View, IGameDebugListener
{
    public Text text;

    public void OnDebug(GameEntity entity, string value)
    {
        text.text = value;
    }

    protected override IObservable<bool> Initialize (IEntity entity, IContext context)
    {
        return Observable.Return(true);
    }

    protected override void RegisterListeners(IEntity entity, IContext context)
    {
        var e = (GameEntity)entity;
        e.AddGameDebugListener(this);
    }

    protected override void UnregisterListeners (IEntity entity, IContext context)
    {
        var e = (GameEntity)entity;
        e.RemoveGameDebugListener(this);
    }
}

