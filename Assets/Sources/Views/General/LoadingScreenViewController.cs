using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Entitas;
using UnityEngine.SceneManagement;
using UniRx;
using System;

public class LoadingScreenViewController : View, IGameLoadSceneListener, IGameLoadSceneRemovedListener, IGameLoadedViewsCompleteListener, IGameLoadedViewsCompleteRemovedListener
                                            , ILoadEntitiesCompleteListener, ILoadEntitiesCompleteRemovedListener
{
    [SerializeField]
    private Image image;

    private bool isSceneLoaded = false;
    private bool isViewLoaded = false;
    private bool isEntitiesLoaded = false;

    protected override IObservable<bool> Initialize ()
    {
        isSceneLoaded = false;
        isViewLoaded = false;
        isEntitiesLoaded = false;
        return Observable.Return(true);
    }

    protected override void Update ()
    {
        base.Update();
        if (isSceneLoaded && isViewLoaded && isEntitiesLoaded && image.enabled)
        {
            image.enabled = false;
        }
        else if (image.enabled == false && (isSceneLoaded == false || isViewLoaded == false || isEntitiesLoaded == false))
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

    public void OnLoadEntitiesComplete (GameEntity entity)
    {
        isEntitiesLoaded = true;
    }

    public void OnLoadEntitiesCompleteRemoved (GameEntity entity)
    {
        isEntitiesLoaded = false;
    }

    protected override void RegisterListeners (IEntity entity, IContext context)
    {
        var gameEntity = (GameEntity)entity;

        gameEntity.AddGameLoadSceneListener(this);
        gameEntity.AddGameLoadSceneRemovedListener(this);
        gameEntity.AddGameLoadedViewsCompleteListener(this);
        gameEntity.AddGameLoadedViewsCompleteRemovedListener(this);
        gameEntity.AddLoadEntitiesCompleteListener(this);
        gameEntity.AddLoadEntitiesCompleteRemovedListener(this);
    }

    protected override void UnregisterListeners (IEntity entity, IContext context)
    {
        var gameEntity = (GameEntity)entity;
        gameEntity.RemoveGameLoadSceneListener(this);
        gameEntity.RemoveGameLoadSceneRemovedListener(this);
        gameEntity.RemoveGameLoadedViewsCompleteListener(this);
        gameEntity.RemoveGameLoadedViewsCompleteRemovedListener(this);
        gameEntity.RemoveLoadEntitiesCompleteListener(this);
        gameEntity.RemoveLoadEntitiesCompleteRemovedListener(this);
    }
}
