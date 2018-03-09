using UnityEngine;
using System.Collections;
using Entitas;
using Entitas.Unity;

public abstract class View : MonoBehaviour, IView
{
    private EntityLink _entity;

    public GameObject instance { get { return this.gameObject; } }
    public EntityLink entity { get { return _entity; } }

    public abstract void Show();
    public abstract void Hide();

    public virtual void Link(IEntity entity, IContext context)
    {
        _entity = instance.Link(entity, context);
    }
    public virtual void Unlink()
    {
        _entity.Unlink();
    }

    protected virtual void Awake() { }
    protected virtual void Start() { }
    protected virtual void Update() { }
    protected virtual void OnEnable() { }
    protected virtual void OnDisable() { }
    protected virtual void OnDestroy() { }
}
