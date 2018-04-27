using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using UniRx;

public class SomeItemUIView : View, IGamePreviewListener, IGamePreviewRemovedListener
{
    [SerializeField]
    private SpriteRenderer _view;

    private Sprite _sprite;

    public void OnPreview (GameEntity entity)
    {
        _view.enabled = false;

        var spriteName = "";
        if (entity.hasFood) { spriteName = entity.food.id; }
        else if (entity.hasApartmentItem) { spriteName = entity.apartmentItem.data.id; }

        if (spriteName != "")
        {
            this.contexts.meta.viewService.instance.GetAsset<Sprite>(spriteName)
                .Subscribe(sprite =>
                {
                    _view.sprite = sprite;
                    _view.enabled = true;
                });
        }
    }

    public void OnPreviewRemoved (GameEntity entity)
    {
    }

    //insert serialized fields here

    protected override IObservable<bool> Initialize (IEntity entity, IContext context)
    {
        return Observable.Return(true);
    }

    protected override void RegisterListeners (IEntity entity, IContext context)
    {
        var gameety = (GameEntity)entity;
        gameety.AddGamePreviewListener(this);
        gameety.AddGamePreviewRemovedListener(this);
    }

    protected override void UnregisterListeners (IEntity entity, IContext context)
    {
        var gameety = (GameEntity)entity;
        gameety.RemoveGamePreviewListener(this);
        gameety.RemoveGamePreviewRemovedListener(this);
    }
}

