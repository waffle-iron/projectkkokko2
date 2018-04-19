using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Entitas;
using UniRx;
using UniRx.Triggers;

public class ApartmentView : View, IValidPlacementListener, IPlaceablePositionListener
{
    //insert serialized fields here
    [SerializeField]
    private SpriteRenderer _valid;
    [SerializeField]
    private Collider2D _col;

    private IDisposable collisionDisposable;

    private Dictionary<uint, CollisionData> _collisions = new Dictionary<uint, CollisionData>();

    public void OnValidPlacement (GameEntity entity, bool state)
    {
        _valid.color = state ? Color.green : Color.red;
    }

    public void OnPlaceablePosition (GameEntity entity, Vector3 current)
    {
        this.transform.position = current;
    }

    protected override void Update ()
    {
        base.Update();
        this.transform.CreatePositionEntity(contexts, this.ID);
    }

    protected override void OnTriggerEnter2D (Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        var view = collision.GetComponentInChildren<View>();

        if (view != null)
        {
            _collisions[view.ID] = new CollisionData(view.ID, CollisionType.ENTER);
        }
    }

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
        collisionDisposable = Observable.EveryUpdate()
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
        gameety.AddValidPlacementListener(this);
        gameety.AddPlaceablePositionListener(this);
    }

    protected override void UnregisterListeners (IEntity entity, IContext context)
    {
        var gameety = (GameEntity)entity;
        gameety.RemoveValidPlacementListener(this);
        gameety.RemovePlaceablePositionListener(this);
    }

}

