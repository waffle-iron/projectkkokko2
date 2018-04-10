using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using UniRx;

public class SoapView : View
{
    //insert serialized fields here

    protected override void OnTriggerStay2D (Collider2D collision)
    {
        base.OnTriggerStay2D(collision);
        collision.CreateCollisionEntity(this.contexts, this.ID, CollisionType.STAY);
    }

    protected override void OnTriggerExit2D (Collider2D collision)
    {
        base.OnTriggerExit2D(collision);
        collision.CreateCollisionEntity(this.contexts, this.ID, CollisionType.EXIT);
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

