using System;
using System.Collections.Generic;
using Entitas;

class ReloadEquippedItemsConfig : UnityEntityConfig
{
    protected override IEntity CustomCreate (Contexts contexts)
    {
        var gameEty = contexts.game.CreateEntity();

        gameEty.isReloadEquipment = true;

        return gameEty;
    }
}

