using System;
using System.Collections.Generic;
using System.Linq;
using Entitas;
using UniRx;
using UnityEngine;

public class PauseView : View, IGamePauseListener, IGamePauseRemovedListener
{
    protected override IObservable<bool> Initialize (IEntity entity, IContext context)
    {
        return Observable.Return(true);
    }

    public void OnPause (GameEntity entity, bool state)
    {
        if (state == true)
        {
            Time.timeScale = 0f;
        }
        else { Time.timeScale = 1f; }
    }

    public void OnPauseRemoved (GameEntity entity)
    {

    }

    protected override void RegisterListeners (IEntity entity, IContext context)
    {
        var gameEntity = (GameEntity)entity;
        gameEntity.AddGamePauseListener(this);
        gameEntity.AddGamePauseRemovedListener(this);
    }

    protected override void UnregisterListeners (IEntity entity, IContext context)
    {
        var gameEntity = (GameEntity)entity;
        gameEntity.RemoveGamePauseListener(this);
        gameEntity.RemoveGamePauseRemovedListener(this);
    }
}

