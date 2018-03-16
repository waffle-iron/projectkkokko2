using System;
using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine;

public class PauseView : View, IGamePauseListener, IGamePauseRemovedListener
{

    public void OnPause (GameEntity entity, bool state)
    {
        
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

