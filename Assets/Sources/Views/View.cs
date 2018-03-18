using UnityEngine;
using System.Collections;
using Entitas;
using Entitas.Unity;

public abstract class View : MonoBehaviour, IView, IGameToDestroyListener
{
    private EntityLink _entity;

    public GameObject Instance { get { return this.gameObject; } }
    public EntityLink EntityLink { get { return _entity; } private set { _entity = value; } }

    protected Contexts contexts { get { return Contexts.sharedInstance; } }

    public void Link (IEntity entity, IContext context)
    {
        if (EntityLink != null && EntityLink.entity != null) { return; }

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
        RegisterListeners(entity, context);
    }
    public void Unlink ()
    {
        if (EntityLink != null && EntityLink.entity != null)
        {
            UnregisterListeners(EntityLink.entity, EntityLink.context);
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

    protected virtual void Awake () { }
    protected virtual void Start () { }
    protected virtual void Update () { }
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
