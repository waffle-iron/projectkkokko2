using System;
using System.Collections.Generic;
using System.Linq;
using Entitas;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class FoodView : View, IGameFoodListener
{
    [SerializeField]
    private Image _image;

    public void OnFood (GameEntity entity, string id, float recovery)
    {

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
        gameEtty.AddGameFoodListener(this);
    }

    protected override void UnregisterListeners (IEntity entity, IContext context)
    {
        var gameEtty = (GameEntity)entity;
        gameEtty.RemoveGameFoodListener(this);
    }
}

