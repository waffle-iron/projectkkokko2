using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;


public class EquippedItemsConfig : UnityEntityConfig
{
    protected override IEntity CustomCreate (Contexts contexts)
    {
        contexts.game.SetEquippedItems(new List<string>());

        contexts.game.equippedItemsEntity.isDoNotDestroyOnSceneChange = true;

        return contexts.game.equippedItemsEntity;
    }
}

