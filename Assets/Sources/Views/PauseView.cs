using System;
using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine;

public class PauseView : View, IGamePauseListener, IGamePauseRemovedListener
{
    [SerializeField]
    private bool _isEnabled = true;

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

    private void OnApplicationFocus (bool focus)
    {
        if (_isEnabled)
        {
            //sa focus kasi it assures running OnPause para maka execute ng logic before closing the app
            Contexts.sharedInstance.input.CreateEntity().AddPause(!focus);
        }
    }
}

