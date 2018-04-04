using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using UniRx;

public class ObstacleView : View
{
    //insert serialized fields here
    protected override void OnCollisionEnter2D (Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        collision.CreateCollisionEntity(contexts, this.ID, CollisionType.ENTER);
    }

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

