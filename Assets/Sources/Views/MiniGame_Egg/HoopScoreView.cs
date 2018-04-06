using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using UniRx;

public class HoopScoreView : View, IGameGameStateListener
{
    //insert serialized fields here
    [SerializeField]
    private Transform root;

    protected override void OnTriggerEnter2D (Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        collision.CreateCollisionEntity(contexts, this.ID, CollisionType.ENTER);
    }

    public void OnGameState (GameEntity entity, GameState current)
    {
        if (current.IsEqualTo(MiniGameEggState.SETUP_GAME))
        {
            var newPos = PositionsReference.Instance.ringLeftRange.RandomXPosition(PositionsReference.Instance.ringRightRange);
            root.ReplaceXPos(newPos.x);
        }
    }

    protected override IObservable<bool> Initialize (IEntity entity, IContext context)
    {
        return Observable.Return(true);
    }

    protected override void RegisterListeners (IEntity entity, IContext context)
    {
        var gameety = (GameEntity)entity;
        gameety.AddGameGameStateListener(this);
    }

    protected override void UnregisterListeners (IEntity entity, IContext context)
    {
        var gameety = (GameEntity)entity;
        gameety.RemoveGameGameStateListener(this);
    }
}

