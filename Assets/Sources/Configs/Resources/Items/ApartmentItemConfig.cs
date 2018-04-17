using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using UniRx;

public class ApartmentItemConfig : UnityEntityConfig
{
    //enter serialized fields here
    [Header("Apartment Item Settings")]
    [SerializeField]
    private string apartmentItemID;
    [SerializeField]
    private ApartmentItemType type;


    protected override IEntity CustomCreate (Contexts contexts)
    {
        var gameEty = contexts.game.CreateEntity();
        gameEty.AddApartmentItem(type, apartmentItemID);
        gameEty.AddMoveable(1f);
        gameEty.isCollidable = true;

        return gameEty;
    }
}

