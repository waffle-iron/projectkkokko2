using UnityEngine;
using System.Collections;
using Entitas;
using System;
using UniRx;

public class EggView : View, IVelocityListener, IGameGameStateListener
{
    [SerializeField]
    private Rigidbody2D _rigidbody;
    [SerializeField]
    private float clampForce;

    protected override void Awake ()
    {
        base.Awake();
        if (_rigidbody == null) { _rigidbody = GetComponentInChildren<Rigidbody2D>(); }
    }

    public void OnVelocity (GameEntity entity, Vector3 current)
    {
        //do unity logic here
        var curr = current;
        //curr.y = clampForce;
        _rigidbody.AddForce(curr, ForceMode2D.Impulse);

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
    }

    protected override void UnregisterListeners (IEntity entity, IContext context)
    {
        var gameety = (GameEntity)entity;
        gameety.RemoveVelocityListener(this);
        gameety.RemoveGameGameStateListener(this);

    }

    public void OnGameState (GameEntity entity, GameState current)
    {
        if (current.Equals(MiniGameEggState.SETUP_GAME))
        {

        }
    }
}
