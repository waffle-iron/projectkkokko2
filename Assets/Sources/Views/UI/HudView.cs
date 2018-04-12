using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using UniRx;

public class HudView : View, IHudListener
{
    //insert serialized fields here
    [SerializeField]
    private Transform[] huds;

    public void OnHud (GameEntity entity, bool state)
    {
        foreach (var hud in huds)
        {
            hud.gameObject.SetActive(state);
        }
    }

    protected override IObservable<bool> Initialize (IEntity entity, IContext context)
    {
        return Observable.Return(true);
    }

    protected override void RegisterListeners (IEntity entity, IContext context)
    {
        var gameety = (GameEntity)entity;
        gameety.AddHudListener(this);
    }

    protected override void UnregisterListeners (IEntity entity, IContext context)
    {
        var gameety = (GameEntity)entity;
        gameety.RemoveHudListener(this);
    }
}

