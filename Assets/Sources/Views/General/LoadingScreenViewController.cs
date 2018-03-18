using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Entitas;

public class LoadingScreenViewController : View, IGameLoadSceneListener, IGameLoadSceneRemovedListener
{
    [SerializeField]
    private Image image;

    protected override void Start ()
    {
        base.Start();
        image.enabled = false;
    }

    public void OnLoadScene (GameEntity entity, string name)
    {
        image.enabled = true;
    }

    public void OnLoadSceneRemoved (GameEntity entity)
    {
        image.enabled = false;
    }

    protected override void RegisterListeners (IEntity entity, IContext context)
    {
        var gameEntity = (GameEntity)entity;

        gameEntity.AddGameLoadSceneListener(this);
        gameEntity.AddGameLoadSceneRemovedListener(this);
    }

    protected override void UnregisterListeners (IEntity entity, IContext context)
    {
        var gameEntity = (GameEntity)entity;
        gameEntity.RemoveGameLoadSceneListener(this);
        gameEntity.RemoveGameLoadSceneRemovedListener(this);
    }
}
