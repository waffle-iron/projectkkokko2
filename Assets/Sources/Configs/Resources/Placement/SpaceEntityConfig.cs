using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using UniRx;

public class SpaceEntityConfig : UnityEntityConfig
{
    //enter serialized fields here
    [Header("Space Settings")]
    [SerializeField]
    private ApartmentItemType _acceptedType;

    protected override IEntity CustomCreate (Contexts contexts)
    {
        var gameEty = contexts.game.CreateEntity();
        gameEty.isSpace = true;
        gameEty.isCollidable = true;
        gameEty.AddApartmentItem(new ApartmentItemData(_acceptedType, ""));

        return gameEty;
    }
}

