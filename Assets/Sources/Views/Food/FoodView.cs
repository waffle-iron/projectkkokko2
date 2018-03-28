using System;
using System.Collections.Generic;
using System.Linq;
using Entitas;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class FoodView : View, IGameConsumingListener, IGameConsumingRemovedListener
{
    [SerializeField]
    private Image _image;

    public void OnConsuming (GameEntity entity)
    {
        _image.enabled = false;
    }

    public void OnConsumingRemoved (GameEntity entity)
    {
        _image.enabled = true;
    }

    public void OnClick ()
    {
        var inputEty = this.contexts.input.CreateEntity();
        inputEty.AddTargetEntityID(this.ID);
        inputEty.isConsuming = true;
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
        gameEtty.AddGameConsumingListener(this);
        gameEtty.AddGameConsumingRemovedListener(this);
    }

    protected override void UnregisterListeners (IEntity entity, IContext context)
    {
        var gameEtty = (GameEntity)entity;
        gameEtty.RemoveGameConsumingListener(this);
        gameEtty.RemoveGameConsumingRemovedListener(this);
    }
}

