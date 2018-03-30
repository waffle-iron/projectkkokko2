using UnityEngine;
using System.Collections;
using Entitas;
using Entitas.Unity;
using System;
using UniRx;

public abstract class View : MonoBehaviour, IView, IGameToDestroyListener
{
    private EntityLink _entity;
    private uint _id = 0;

    public GameObject Instance { get { return this.gameObject; } }
    public EntityLink EntityLink { get { return _entity; } private set { _entity = value; } }
    public uint ID
    {
        get {
            return _id;
        }
    }

    protected Contexts contexts { get { return Contexts.sharedInstance; } }


    private IDisposable _initObservable;
    private bool _isInitialized = false;

    public void Link (IEntity entity, IContext context)
    {
        //return to pool if entity is already linked to a view
        //if (EntityLink != null && EntityLink.entity != null)
        //{
        //    this.gameObject.SetActive(false);
        //    return;
        //}

        _id = ((IIDEntity)entity).iD.value;

        if (Instance.GetEntityLink() != null)
        {
            EntityLink = Instance.GetEntityLink();
        }
        else
        {
            EntityLink = Instance.Link(entity, context);
        }

        var gameEntity = (GameEntity)entity;
        gameEntity.AddGameToDestroyListener(this);

        _isInitialized = false;
        //Debug.Log(this.name);
        _initObservable = Initialize(entity, context)
            //.Do(_ => Debug.Log(this.name))
            .Where(state => state == true)
            .First()
            .Subscribe(_ =>
            {
                _isInitialized = true;
                RegisterListeners(entity, context);
            });
    }
    public void Unlink ()
    {
        if (_initObservable != null) { _initObservable.Dispose(); }
        if (EntityLink != null && EntityLink.entity != null)
        {
            if (_isInitialized)
            {
                Cleanup();
                UnregisterListeners(EntityLink.entity, EntityLink.context);
            }
            //Debug.Log(this.name);
            //((GameEntity)EntityLink.entity).RemoveGameToDestroyListener(this);
            EntityLink.Unlink();
            EntityLink = null;
            //return to pool by falsing
            this.gameObject.SetActive(false);
        }
    }

    protected abstract void RegisterListeners (IEntity entity, IContext context);
    protected abstract void UnregisterListeners (IEntity entity, IContext context);
    protected abstract IObservable<bool> Initialize (IEntity entity, IContext context);

    protected virtual void Cleanup () { }
    protected virtual void Awake () { }
    protected virtual void Start () { }
    protected virtual void Update () { }
    protected virtual void FixedUpdate () { }
    protected virtual void LateUpdate () { }
    protected virtual void OnTriggerEnter (Collider other) { }
    protected virtual void OnTriggerStay (Collider other) { }
    protected virtual void OnTriggerExit (Collider other) { }
    protected virtual void OnTriggerEnter2D (Collider2D collision) { }
    protected virtual void OnTriggerStay2D (Collider2D collision) { }
    protected virtual void OnTriggerExit2D (Collider2D collision) { }
    protected virtual void OnCollisionEnter (Collision collision) { }
    protected virtual void OnCollisionStay (Collision collision) { }
    protected virtual void OnCollisionExit (Collision collision) { }
    protected virtual void OnCollisionEnter2D (Collision2D collision) { }
    protected virtual void OnCollisionStay2D (Collision2D collision) { }
    protected virtual void OnCollisionExit2D (Collision2D collision) { }
    protected virtual void OnEnable () { }
    protected virtual void OnDisable () { }
    protected virtual void OnDestroy ()
    {
        if (EntityLink != null && EntityLink.entity != null)
        {
            ((GameEntity)EntityLink.entity).RemoveGameToDestroyListener(this);
        }
        Unlink();
    }

    public void OnToDestroy (GameEntity entity)
    {
        Unlink();
    }
}
