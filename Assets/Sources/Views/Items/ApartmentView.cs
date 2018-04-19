using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Entitas;
using UniRx;
using UniRx.Triggers;

public class ApartmentView : View
{
    //insert serialized fields here
    private IDisposable collisionDisposable;

    private Dictionary<uint, CollisionData> _collisions = new Dictionary<uint, CollisionData>();

    protected override void OnTriggerStay2D (Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        var view = collision.GetComponentInChildren<View>();

        if (view != null)
        {
            _collisions[view.ID] = new CollisionData(view.ID, CollisionType.STAY);

        }
    }

    protected override void OnTriggerExit2D (Collider2D collision)
    {
        base.OnTriggerExit2D(collision);
        var view = collision.GetComponentInChildren<View>();

        if (view != null)
        {
            _collisions[view.ID] = new CollisionData(view.ID, CollisionType.EXIT);
        }
    }

    protected override IObservable<bool> Initialize (IEntity entity, IContext context)
    {
        collisionDisposable = Observable.EveryFixedUpdate().ThrottleFrame(1)
        .Subscribe(_ =>
        {
            if (_collisions.Count > 0)
            {
                CollisionExtensions.CreateCollisionEntity(_collisions.Values.ToArray(), contexts, this.ID);
                _collisions.Clear();
            }
        });
        return Observable.Return(true);
    }

    protected override void Cleanup ()
    {
        base.Cleanup();
        collisionDisposable.Dispose();
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

