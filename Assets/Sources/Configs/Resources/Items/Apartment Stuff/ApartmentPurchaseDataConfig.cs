using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using UniRx;

public class ApartmentPurchaseDataConfig : UnityEntityConfig
{
    //enter serialized fields here
    [Header("Apartment Purchase Data")]
    [SerializeField]
    private List<string> _initPurchases = new List<string>();

    protected override IEntity CustomCreate (Contexts contexts)
    {
        var gameEty = contexts.game.CreateEntity();
        gameEty.AddApartmentItemsPurchasedList(_initPurchases);
        gameEty.isDoNotDestroyOnSceneChange = true;
        return gameEty;
    }
}

