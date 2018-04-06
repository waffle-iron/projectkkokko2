using UnityEngine;
using System.Collections;
using Entitas;
using System;
using UniRx;
using DG.Tweening;

public class EggView : View, IVelocityListener, IGameGameStateListener, ITargetDirectionCheckResultListener
{
    [SerializeField]
    private Rigidbody2D _rigidbody;

    [SerializeField, Tag]
    private string _targetBasket;

    private Transform _basket;

    protected override void Awake ()
    {
        base.Awake();
        if (_rigidbody == null) { _rigidbody = GetComponentInChildren<Rigidbody2D>(); }
        _basket = GameObject.FindGameObjectWithTag(_targetBasket).transform;
    }

    protected override void Update ()
    {
        base.Update();
        this.transform.CreatePositionEntity(contexts, this.ID);

        _basket.transform.CreateTargetPositionEntity(contexts, this.ID);
    }

    public void OnVelocity (GameEntity entity, Vector3 current)
    {
        _rigidbody.AddForce(entity.velocity.current, ForceMode2D.Impulse);

        var inputety = contexts.input.CreateEntity();
        inputety.AddGameState(new GameState(MiniGameEggState.SHOOT));
        inputety.AddDelayDestroy(1);
    }

    protected override IObservable<bool> Initialize (IEntity entity, IContext context)
    {
        return Observable.Return(true);
    }

    protected override void RegisterListeners (IEntity entity, IContext context)
    {
        var gameety = (GameEntity)entity;
        gameety.AddVelocityListener(this);
        gameety.AddGameGameStateListener(this);
        gameety.AddTargetDirectionCheckResultListener(this);
    }

    protected override void UnregisterListeners (IEntity entity, IContext context)
    {
        var gameety = (GameEntity)entity;
        gameety.RemoveVelocityListener(this);
        gameety.RemoveGameGameStateListener(this);
        gameety.RemoveTargetDirectionCheckResultListener(this);
    }

    public void OnGameState (GameEntity entity, GameState current)
    {
        if (current.IsEqualTo(MiniGameEggState.SETUP_GAME))
        {
            //set ball in starting position
            this.transform.position = PositionsReference.Instance.startBall.position;
            _rigidbody.velocity = Vector2.zero;
            _rigidbody.angularVelocity = 0f;
        }
    }

    public void OnTargetDirectionCheckResult (GameEntity entity, bool isInFOV, Vector3 idealDirection)
    {
        //if (isInFOV)
        //{
        //    _rigidbody.AddForce(idealDirection * entity.velocity.current.magnitude, ForceMode2D.Impulse);

        //    var inputety = contexts.input.CreateEntity();
        //    inputety.AddGameState(new GameState(MiniGameEggState.SHOOT));
        //    inputety.AddDelayDestroy(1);
        //}
        //else if (isInFOV == false && entity.hasVelocity)
        //{
        //    _rigidbody.AddForce(entity.velocity.current, ForceMode2D.Impulse);

        //    var inputety = contexts.input.CreateEntity();
        //    inputety.AddGameState(new GameState(MiniGameEggState.SHOOT));
        //    inputety.AddDelayDestroy(1);
        //}

    }
}
