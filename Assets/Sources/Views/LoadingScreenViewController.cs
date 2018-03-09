using UnityEngine;
using System.Collections;
using Entitas;

public class LoadingScreenViewController : View, IGameLoadSceneListener, IGameLoadSceneRemovedListener
{
    public override void Hide ()
    {
        this.instance.SetActive(false);
    }

    public override void Show ()
    {
        this.instance.SetActive(true);
    }

    public override void Link (IEntity entity, IContext context)
    {
        base.Link(entity, context);
        ((GameEntity)entity).AddGameLoadSceneListener(this);
        ((GameEntity)entity).AddGameLoadSceneRemovedListener(this);
    }

    public void OnLoadScene (GameEntity entity, string name)
    {
        Show();
    }

    public void OnLoadSceneRemoved (GameEntity entity)
    {
        Hide();
        this.Unlink();
        UnityViewService.Unload(this);
    }
}
