using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using UniRx;

public class ApartmentPurchaseDataConfig : UnityEntityConfig
{
    //enter serialized fields here

    protected override IEntity CustomCreate (Contexts contexts)
    {
        var gameEty = contexts.game.CreateEntity();
        gameEty.AddApartmentItemsPurchasedList(new Dictionary<string, ApartmentItemData>());
        gameEty.isDoNotDestroyOnSceneChange = true;
        return gameEty;
    }
}

