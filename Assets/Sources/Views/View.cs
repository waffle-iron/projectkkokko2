﻿using UnityEngine;
using System.Collections;
using Entitas;
using Entitas.Unity;

public abstract class View : MonoBehaviour, IView, IGameToDestroyListener
{
    private EntityLink _entity;

    public GameObject instance { get { return this.gameObject; } }
    public EntityLink entity { get { return _entity; } }

    protected Contexts contexts { get { return Contexts.sharedInstance; } }

    public void Link (IEntity entity, IContext context)
    {
        _entity = instance.Link(entity, context);
        var gameEntity = (GameEntity)entity;
        gameEntity.AddGameToDestroyListener(this);
        RegisterListeners(entity, context);
    }
    public void Unlink ()
    {
        _entity.Unlink();
        UnityViewService.Unload(this);
    }

    protected abstract void RegisterListeners (IEntity entity, IContext context);

    protected virtual void Awake () { }
    protected virtual void Start () { }
    protected virtual void Update () { }
    protected virtual void OnEnable () { }
    protected virtual void OnDisable () { }
    protected virtual void OnDestroy () { }

    public void OnToDestroy (GameEntity entity)
    {
        Unlink();
    }
}
