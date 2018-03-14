using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;


public class EquippedItemsConfig : UnityEntityConfig
{
    protected override IEntity CustomCreate (Contexts contexts)
    {
        var gameEntity = contexts.game.CreateEntity();

        gameEntity.AddEquippedItems(new List<AccessoryID>());

        return gameEntity;
    }
}

