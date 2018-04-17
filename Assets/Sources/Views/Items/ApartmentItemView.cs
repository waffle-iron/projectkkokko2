using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using UniRx;

public class ApartmentItemView : View, IValidGridListener, IValidGridRemovedListener, IGameTouchDataListener
{
    //insert serialized fields here
    [SerializeField]
    private SpriteRenderer _spriteRenderer;
    [SerializeField]
    private Collider2D _col;
    [SerializeField]
    private Rigidbody2D _body;

    protected override void OnTriggerEnter2D (Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        collision.CreateCollisionEntity(contexts, this.ID, CollisionType.ENTER);
    }

    protected override void OnTriggerExit2D (Collider2D collision)
    {
        base.OnTriggerExit2D(collision);
        collision.CreateCollisionEntity(contexts, this.ID, CollisionType.EXIT);
    }

    public void OnTouchData (GameEntity entity, TouchData current)
    {
        if (_body.simulated == false && current.Phase == TouchPhase.Began || current.Phase == TouchPhase.Moved)
        {
            _body.simulated = true;
        }
        else if (_body.simulated == true && current.Phase == TouchPhase.Ended || current.Phase == TouchPhase.Canceled)
        {
            _body.simulated = false;
        }
    }

    public void OnValidGrid (GameEntity entity)
    {
        _spriteRenderer.color = Color.white;
    }

    public void OnValidGridRemoved (GameEntity entity)
    {
        _spriteRenderer.color = Color.red;
    }

    protected override IObservable<bool> Initialize (IEntity entity, IContext context)
    {
        return Observable.Return(true);
    }

    protected override void RegisterListeners (IEntity entity, IContext context)
    {
        var gameety = (GameEntity)entity;
        gameety.AddValidGridListener(this);
        gameety.AddValidGridRemovedListener(this);
    }

    protected override void UnregisterListeners (IEntity entity, IContext context)
    {
        var gameety = (GameEntity)entity;
        gameety.RemoveValidGridListener(this);
        gameety.RemoveValidGridRemovedListener(this);
    }
}

