using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Entitas;
using UniRx;

public class ApartmentUIView : View
{
    //insert serialized fields here
    [SerializeField]
    private Image _sprite;
    [SerializeField]
    private SpawnItemOnDrag _spawner;

    protected override IObservable<bool> Initialize (IEntity entity, IContext context)
    {
        var gameety = (GameEntity)entity;
        Debug.Assert(gameety.hasApartmentItem);
        //Debug.Assert(gameety.hasEntity && gameety.entity.entities.Length > 0);

        //_spawner.entityID = gameety.entity.entities[0];

        var service = this.contexts.meta.viewService.instance;
        return service.GetAsset<Sprite>(gameety.apartmentItem.data.id, newSprite => { _sprite.sprite = newSprite; });
    }

    protected override void RegisterListeners (IEntity entity, IContext context)
    {
        var gameety = (GameEntity)entity;
    }

    protected override void UnregisterListeners (IEntity entity, IContext context)
    {
        var gameety = (GameEntity)entity;
    }
}

