using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Entitas;
using UniRx;

public class SleepView : View, ISleepListener, ISleepRemovedListener
{
    //insert serialized fields here
    [SerializeField]
    private Image _image;

    public void OnSleep (GameEntity entity)
    {
        _image.enabled = true;
    }

    public void OnSleepRemoved (GameEntity entity)
    {
        _image.enabled = false;
    }

    protected override IObservable<bool> Initialize (IEntity entity, IContext context)
    {
        return Observable.Return(true);
    }

    protected override void RegisterListeners (IEntity entity, IContext context)
    {
        var gameety = (GameEntity)entity;
        gameety.AddSleepListener(this);
        gameety.AddSleepRemovedListener(this);
    }

    protected override void UnregisterListeners (IEntity entity, IContext context)
    {
        var gameety = (GameEntity)entity;
        gameety.RemoveSleepListener(this);
        gameety.RemoveSleepRemovedListener(this);
    }
}

