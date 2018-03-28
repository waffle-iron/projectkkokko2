using System;
using System.Collections.Generic;
using Entitas;
using Spine.Unity;
using UnityEngine;
using UniRx;

public class PlayerView : View, IGameTargetMoveListener
{
    public SpineSkeleton _player;
    [SerializeField]
    private Transform _playerTransform;
    [SerializeField]
    private float _speed;

    private IDisposable _movement;

    public void OnTargetMove (GameEntity entity, Vector3 position)
    {
        if (_movement != null) { _movement.Dispose(); }

        _speed = entity?.moveable.speed ?? _speed;
        var targetPosition = _playerTransform.position;
        targetPosition.x = position.x;

        _movement = Observable.EveryUpdate().Subscribe(_ =>
        {
            _playerTransform.position = Vector3.MoveTowards(_playerTransform.position, targetPosition, _speed * Time.deltaTime);

            var inputEty = contexts.input.CreateEntity();
            inputEty.AddTargetEntityID(this.ID);
            inputEty.AddPosition(_playerTransform.position);

            if (Mathf.Abs(_playerTransform.position.x - targetPosition.x) < 0.1f) { _movement.Dispose(); }

        });
    }

    protected override IObservable<bool> Initialize (IEntity entity, IContext context)
    {
        return Observable.Return(true);
    }

    protected override void RegisterListeners (IEntity entity, IContext context)
    {
        var gameEty = (GameEntity)entity;
        gameEty.AddGameTargetMoveListener(this);
    }

    protected override void UnregisterListeners (IEntity entity, IContext context)
    {
        var gameEty = (GameEntity)entity;
        gameEty.RemoveGameTargetMoveListener(this);
    }
}

