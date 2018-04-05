using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using UniRx;

public class ObstacleView : View, IGameMoveableListener
{
    [SerializeField]
    private float xSpeed = 0f;

    protected override void OnEnable ()
    {
        base.OnEnable();
    }

    protected override void Update ()
    {
        base.Update();
        transform.Translate((Vector3.right * xSpeed) * Time.deltaTime);
        transform.CreatePositionEntity(contexts, this.ID);

    }

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

    public void OnMoveable (GameEntity entity, float speed)
    {
        this.xSpeed = speed;
    }

    protected override IObservable<bool> Initialize (IEntity entity, IContext context)
    {
        var gameEty = (GameEntity)entity;
        if (gameEty.hasMoveable)
        {
            this.xSpeed = gameEty.moveable.speed;

            //set spawn position;
            if (xSpeed > 0f)
            {
                transform.position = PositionsReference.Instance.obstacleSpawnLeftPos.position;
            }
            else if (xSpeed < 0f)
            {
                transform.position = PositionsReference.Instance.obstacleSpawnRightPos.position;
            }
        }

        return Observable.Return(true);
    }

    protected override void RegisterListeners (IEntity entity, IContext context)
    {
        var gameety = (GameEntity)entity;
        gameety.AddGameMoveableListener(this);
    }

    protected override void UnregisterListeners (IEntity entity, IContext context)
    {
        var gameety = (GameEntity)entity;
        gameety.RemoveGameMoveableListener(this);
    }

}

