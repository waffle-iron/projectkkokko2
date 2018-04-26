using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Entitas;
using UniRx;

public class ApartmentItemSpawnerView : View
{
    [SerializeField]
    private SpawnItemOnDrag _spawner;

    protected override IObservable<bool> Initialize (IEntity entity, IContext context)
    {
        var gameety = (GameEntity)entity;
        Debug.Assert(gameety.hasApartmentItemsPurchasedList);

        var aptItems = gameety.apartmentItemsPurchasedList._cfgIds;

        var service = this.contexts.meta.viewService.instance;

        if (aptItems.Count > 0)
        {
            foreach (var item in aptItems)
            {
                var instance = GameObject.Instantiate(_spawner, _spawner.transform.parent, true);
                instance.entityID = item.Key;
                instance.SetImage(item.Value.id, service);
                instance.gameObject.SetActive(true);
            }
        }

        return Observable.Return(true);
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

