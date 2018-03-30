
using System;
using System.Collections.Generic;
using System.Linq;
using Entitas;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class FoodUIView : View, IGameRemoveFromStorageListener, IGameRemoveFromStorageRemovedListener
{
    [SerializeField]
    private Image _image;

    public void OnRemoveFromStorage (GameEntity entity)
    {
        _image.enabled = false;
    }

    public void OnRemoveFromStorageRemoved (GameEntity entity)
    {
        _image.enabled = true;
    }

    public void OnClick ()
    {
        var inputEty = this.contexts.input.CreateEntity();
        inputEty.AddTargetEntityID(this.ID);
        inputEty.isRemoveFromStorage = true;
    }

    protected override IObservable<bool> Initialize (IEntity entity, IContext context)
    {
        var gameEtty = (GameEntity)entity;
        if (gameEtty.hasFood)
        {
            return this.contexts.meta.viewService.instance.GetAsset<Sprite>(gameEtty.food.id, (sprite) =>
            {
                _image.sprite = sprite;
            });
        }

        return Observable.Return(true);
    }

    protected override void RegisterListeners (IEntity entity, IContext context)
    {
        var gameEtty = (GameEntity)entity;
        gameEtty.AddGameRemoveFromStorageListener(this);
        gameEtty.AddGameRemoveFromStorageRemovedListener(this);
    }

    protected override void UnregisterListeners (IEntity entity, IContext context)
    {
        var gameEtty = (GameEntity)entity;
        gameEtty.RemoveGameRemoveFromStorageListener(this);
        gameEtty.RemoveGameRemoveFromStorageRemovedListener(this);
    }

}

