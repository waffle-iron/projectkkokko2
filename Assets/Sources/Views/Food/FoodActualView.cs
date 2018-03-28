using UnityEngine;
using System.Collections;
using Entitas;
using System;
using UniRx;

public class FoodActualView : View
{
    [SerializeField]
    private SpriteRenderer _sprite;

    protected override IObservable<bool> Initialize (IEntity entity, IContext context)
    {
        _sprite.enabled = false;
        var gameEty = ((GameEntity)entity);
        var food = gameEty.food;
        return this.contexts.meta.viewService.instance.GetAsset<Sprite>(food.id, (sprite) =>
        {
            _sprite.sprite = sprite;
            _sprite.enabled = true;
        });
    }

    protected override void RegisterListeners (IEntity entity, IContext context)
    {
        var gameEty = ((GameEntity)entity);

    }

    protected override void UnregisterListeners (IEntity entity, IContext context)
    {
        var gameEty = ((GameEntity)entity);
    }
}
