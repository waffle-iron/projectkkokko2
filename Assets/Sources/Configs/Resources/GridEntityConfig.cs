using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using UniRx;

public class GridEntityConfig : UnityEntityConfig
{
    //enter serialized fields here
    [Header("Grid Settings")]
    [SerializeField]
    private string id;
    [SerializeField]
    private ApartmentItemType acceptedType;

    protected override IEntity CustomCreate (Contexts contexts)
    {
        var gameEty = contexts.game.CreateEntity();
        gameEty.AddGrid(id);
        gameEty.isCollidable = true;
        gameEty.AddApartmentItem(acceptedType, "");

        return gameEty;
    }
}

