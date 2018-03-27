using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;


public class EquippedItemsConfig : UnityEntityConfig
{
    [SerializeField, SceneName]
    private List<string> _filterInScenes;

    protected override IEntity CustomCreate (Contexts contexts)
    {
        contexts.game.SetEquippedItems(new List<string>(), _filterInScenes);

        contexts.game.equippedItemsEntity.isDoNotDestroyOnSceneChange = true;

        return contexts.game.equippedItemsEntity;
    }
}

