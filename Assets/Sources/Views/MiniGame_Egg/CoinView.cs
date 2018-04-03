using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using UniRx;

public class CoinView : View
{
    //insert serialized fields here

    protected override void OnTriggerEnter2D (Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        collision.CreateCollisionEntity(contexts, this.ID, CollisionType.ENTER);
    }

    protected override IObservable<bool> Initialize (IEntity entity, IContext context)
    {
        return Observable.Return(true);
    }

    protected override void RegisterListeners (IEntity entity, IContext context)
    {
        var gameety = (GameEntity)entity;
    }

    protected override void UnregisterListeners (IEntity entity, IContext context)
    {
        var gameety = (GameEntity)entity;
    }
}

