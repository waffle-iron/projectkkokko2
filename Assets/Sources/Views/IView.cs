using Entitas;
using Entitas.Unity;
using UnityEngine;

public interface IView
{
    GameObject instance { get; }
    EntityLink entity { get; }

    void Show();
    void Hide();

    void Link(IEntity entity, IContext context);
    void Unlink();
}
