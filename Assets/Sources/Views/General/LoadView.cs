using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Entitas;
using CodeStage.AntiCheat.ObscuredTypes;
using UniRx;
using System;

public class LoadView : View, ILoadingListener, ILoadingRemovedListener
{
    private int loadCount = 0;
    [SerializeField]
    private Image image;

    protected override IObservable<bool> Initialize ()
    {
        return Observable.Return(true);
    }

    public void OnLoading (GameEntity entity)
    {
        this.loadCount++;
    }

    public void OnLoadingRemoved (GameEntity entity)
    {
        this.loadCount--;
    }

    protected override void RegisterListeners (IEntity entity, IContext context)
    {
        var gameEntity = (GameEntity)entity;
        gameEntity.AddLoadingListener(this);
        gameEntity.AddLoadingRemovedListener(this);
    }

    protected override void UnregisterListeners (IEntity entity, IContext context)
    {
        var gameEntity = (GameEntity)entity;
        gameEntity.RemoveLoadingListener(this);
        gameEntity.RemoveLoadingRemovedListener(this);
    }

    protected override void Update ()
    {
        base.Update();
        if (loadCount > 0 && image.enabled == false)
        {
            image.gameObject.SetActive(true);
        }
        else if (loadCount == 0 && image.enabled)
        {
            image.gameObject.SetActive(false);
        }
    }
}
