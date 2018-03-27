using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Entitas;
using CodeStage.AntiCheat.ObscuredTypes;
using UniRx;
using System;

public class SaveView : View, ISavingListener, ISavingRemovedListener
{
    private int saveCount = 0;
    [SerializeField]
    private Image image;

    protected override IObservable<bool> Initialize (IEntity entity, IContext context)
    {
        return Observable.Return(true);
    }

    public void OnSaving (GameEntity entity)
    {
        saveCount++;
    }

    public void OnSavingRemoved (GameEntity entity)
    {
        saveCount--;
    }

    protected override void RegisterListeners (IEntity entity, IContext context)
    {
        var gameEntity = (GameEntity)entity;
        gameEntity.AddSavingListener(this);
        gameEntity.AddSavingRemovedListener(this);
    }

    protected override void UnregisterListeners (IEntity entity, IContext context)
    {
        var gameEntity = (GameEntity)entity;
        gameEntity.RemoveSavingListener(this);
        gameEntity.RemoveSavingRemovedListener(this);
    }

    protected override void Update ()
    {
        base.Update();
        if (saveCount > 0 && image.enabled == false)
        {
            image.gameObject.SetActive(true);
        }
        else if (saveCount == 0 && image.enabled)
        {
            image.gameObject.SetActive(false);
        }
    }
}
