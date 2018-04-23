using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using UniRx;

public class ApartmentItemsSavedPurchaseDataConfig : UnityEntityConfig
{
    //enter serialized fields here
    [SerializeField]
    private string[] _init;

    protected override IEntity CustomCreate (Contexts contexts)
    {
        var gameEty = contexts.game.CreateEntity();
        gameEty.isApartmentItemsSavedPurchaseData = true;
        gameEty.AddEntity(_init);

        return gameEty;
    }
}

