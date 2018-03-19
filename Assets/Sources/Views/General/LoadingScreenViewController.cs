using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Entitas;
using UnityEngine.SceneManagement;

public class LoadingScreenViewController : View, IGameLoadSceneListener, IGameLoadSceneRemovedListener, IGameLoadedViewsCompleteListener, IGameLoadedViewsCompleteRemovedListener
{
    [SerializeField]
    private Image image;

    private bool isSceneLoaded = false;
    private bool isViewLoaded = false;

    protected override void Start ()
    {
        base.Start();
        isSceneLoaded = false;
        isViewLoaded = false;
    }

    protected override void Update ()
    {
        base.Update();
        if (isSceneLoaded && isViewLoaded && image.enabled)
        {
            image.enabled = false;
        }
        else if (image.enabled == false && (isSceneLoaded == false || isViewLoaded == false))
        {
            image.enabled = true;
        }
    }

    public void OnLoadScene (GameEntity entity, string name)
    {
        isSceneLoaded = false;
    }

    public void OnLoadSceneRemoved (GameEntity entity)
    {
        isSceneLoaded = true;
    }

    public void OnLoadedViewsComplete (GameEntity entity)
    {
        isViewLoaded = true;
    }

    public void OnLoadedViewsCompleteRemoved (GameEntity entity)
    {
        isViewLoaded = false;
    }

    protected override void RegisterListeners (IEntity entity, IContext context)
    {
        var gameEntity = (GameEntity)entity;

        gameEntity.AddGameLoadSceneListener(this);
        gameEntity.AddGameLoadSceneRemovedListener(this);
        gameEntity.AddGameLoadedViewsCompleteListener(this);
        gameEntity.AddGameLoadedViewsCompleteRemovedListener(this);
    }

    protected override void UnregisterListeners (IEntity entity, IContext context)
    {
        var gameEntity = (GameEntity)entity;
        gameEntity.RemoveGameLoadSceneListener(this);
        gameEntity.RemoveGameLoadSceneRemovedListener(this);
        gameEntity.RemoveGameLoadedViewsCompleteListener(this);
        gameEntity.RemoveGameLoadedViewsCompleteRemovedListener(this);
    }


}
