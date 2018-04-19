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
    private string _id;
    [SerializeField]
    private ApartmentItemType _type;

    protected override IEntity CustomCreate (Contexts contexts)
    {
        var gameEty = contexts.game.CreateEntity();
        gameEty.AddApartmentItem(new ApartmentItemData(_type, _id));
        gameEty.AddMoveable(1f);
        gameEty.isCollidable = true;
        gameEty.isPlaceable = true;
        gameEty.AddValidPlacement(false);

        return gameEty;
    }
}

