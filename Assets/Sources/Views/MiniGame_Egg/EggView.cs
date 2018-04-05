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
    [SerializeField]
    private Collider2D _col;
    [SerializeField]
    private float _animTime = 1f;
    [SerializeField]
    private Ease _ease;
    [SerializeField]
    private float clampForce;
    [SerializeField, Tag]
    private string _targetBasket;

    private Transform _basket;

    private Tween _tween;

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
        //_rigidbody.AddForce(current, ForceMode2D.Impulse);

        //change game state
        //var inputety = contexts.input.CreateEntity();
        //inputety.AddGameState(new GameState(MiniGameEggState.SHOOT));
        //inputety.AddDelayDestroy(1);
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

    public void OnTargetDirectionCheckResult (GameEntity entity, bool isInFOV)
    {
        if (isInFOV)
        {
            var targetPos = _basket.position;
            targetPos.z = this.transform.position.z;
            targetPos.x += UnityEngine.Random.Range(-0.5f, .5f);
            this.transform.DOMove(targetPos, _animTime).SetAutoKill(true)
                .SetEase(_ease)
                .SetRecyclable(true)
                //.OnPlay(() => { this._col.enabled = false; })
                .OnComplete(() => { _rigidbody.velocity = new Vector2(0f, _rigidbody.velocity.y); })
                .Play();

            var inputety = contexts.input.CreateEntity();
            inputety.AddGameState(new GameState(MiniGameEggState.SHOOT));
            inputety.AddDelayDestroy(1);
        }
        else if (isInFOV == false && entity.hasVelocity)
        {
            _rigidbody.AddForce(entity.velocity.current, ForceMode2D.Impulse);

            var inputety = contexts.input.CreateEntity();
            inputety.AddGameState(new GameState(MiniGameEggState.SHOOT));
            inputety.AddDelayDestroy(1);
        }

    }
}
