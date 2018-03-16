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
        image.gameObject.SetActive(false);
    }

    public void OnLoadScene (GameEntity entity, string name)
    {
        image.gameObject.SetActive(true);
    }

    public void OnLoadSceneRemoved (GameEntity entity)
    {
        image.gameObject.SetActive(false);
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
