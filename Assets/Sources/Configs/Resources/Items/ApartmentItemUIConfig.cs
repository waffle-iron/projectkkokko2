using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using UniRx;

public class ApartmentItemUIConfig : UnityEntityConfig
{
    //enter serialized fields here
    [Header("Apartment UI Entity Settings")]
    [SerializeField]
    private ApartmentItemData _data;
    [SerializeField]
    private string _toSpawnEntity;

    protected override IEntity CustomCreate (Contexts contexts)
    {
        var gameEty = contexts.game.CreateEntity();
        gameEty.AddApartmentItem(_data);
        gameEty.AddEntity(new string[] { _toSpawnEntity });

        return gameEty;
    }
}

