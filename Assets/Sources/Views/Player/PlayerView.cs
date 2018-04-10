using System;
using System.Collections.Generic;
using Entitas;
using Spine.Unity;
using UnityEngine;
using UniRx;

public class PlayerView : View, IGameTargetMoveListener, ISleepListener, ISleepRemovedListener
{
    public SpineSkeleton _player;
    [SerializeField]
    private Transform _playerTransform;
    [SerializeField]
    private float _speed;

    private IDisposable _movement;

    private Vector3 targetPosition = Vector3.zero;
    private float stopDistance = 0;

    protected override void Start ()
    {
        base.Start();

        //initialize movement on start
        _movement = Observable.EveryUpdate().Subscribe(_ =>
        {

            if (Mathf.Abs(_playerTransform.position.x - targetPosition.x) > stopDistance)
            {
                _playerTransform.position = Vector3.MoveTowards(_playerTransform.position, targetPosition, _speed * Time.deltaTime);

                var inputEty = contexts.input.CreateEntity();
                inputEty.AddTargetEntityID(this.ID);
                inputEty.AddPosition(_playerTransform.position);

            }

        });
    }

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

    public void OnTargetMove (GameEntity entity, Vector3 position, float stopDistance)
    {
        _speed = entity?.moveable.speed ?? _speed;
        var newPos = _playerTransform.position;
        newPos.x = position.x;
        this.targetPosition = newPos;
        this.stopDistance = stopDistance;
    }

    protected override IObservable<bool> Initialize (IEntity entity, IContext context)
    {
        return Observable.Return(true);
    }

    protected override void RegisterListeners (IEntity entity, IContext context)
    {
        var gameEty = (GameEntity)entity;
        gameEty.AddGameTargetMoveListener(this);
        gameEty.AddSleepListener(this);
        gameEty.AddSleepRemovedListener(this);
    }

    protected override void UnregisterListeners (IEntity entity, IContext context)
    {
        var gameEty = (GameEntity)entity;
        gameEty.RemoveGameTargetMoveListener(this);
        gameEty.RemoveSleepListener(this);
        gameEty.RemoveSleepRemovedListener(this);
    }

    protected override void Cleanup ()
    {
        base.Cleanup();
        _movement?.Dispose();
    }

    public void OnSleep (GameEntity entity)
    {
        Debug.Log("player sleep");
    }

    public void OnSleepRemoved (GameEntity entity)
    {
        Debug.Log("player wake up");
    }
}

