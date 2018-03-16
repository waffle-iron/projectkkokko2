using Entitas;
using Entitas.Unity;
using UnityEngine;

public interface IView
{
    GameObject Instance { get; }
    EntityLink EntityLink { get; }

    void Link(IEntity entity, IContext context);
    void Unlink();
}
