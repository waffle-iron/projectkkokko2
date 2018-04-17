using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using UniRx;

public class GridSquareView : View, IGameOnCollisionListener
{
    //insert serialized fields here
    [SerializeField]
    private SpriteRenderer _spriteRenderer;
    [SerializeField]
    private Collider2D _col;

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

    public void OnOnCollision (GameEntity entity, uint otherID, CollisionType type)
    {
        if (type == CollisionType.ENTER)
        {
            _spriteRenderer.color = Color.blue;
        }
        else if (type == CollisionType.EXIT)
        {
            _spriteRenderer.color = Color.white;
        }
    }

    protected override IObservable<bool> Initialize (IEntity entity, IContext context)
    {
        return Observable.Return(true);
    }

    protected override void RegisterListeners (IEntity entity, IContext context)
    {
        var gameety = (GameEntity)entity;
        gameety.AddGameOnCollisionListener(this);
    }

    protected override void UnregisterListeners (IEntity entity, IContext context)
    {
        var gameety = (GameEntity)entity;
        gameety.RemoveGameOnCollisionListener(this);
    }


}

