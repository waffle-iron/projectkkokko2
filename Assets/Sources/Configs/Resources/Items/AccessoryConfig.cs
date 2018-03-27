using System;
using System.Collections.Generic;
using CodeStage.AntiCheat.ObscuredTypes;
using Entitas;
using UnityEngine;

public class AccessoryConfig : UnityEntityConfig
{
    [Header("Accessory Settings")]
    [SerializeField]
    private string _id;
    [SerializeField]
    private AccessoryType _type;
    [SerializeField]
    private ObscuredInt _price;
    [SerializeField]
    private ObscuredBool _isPurchased;
    [SerializeField]
    private ObscuredBool _isEquipped;


    protected override IEntity CustomCreate (Contexts contexts)
    {
        var gameEntity = contexts.game.CreateEntity();

        gameEntity.AddAccessory(_id, _type);
        gameEntity.AddPrice(_price);
        gameEntity.isPurchased = _isPurchased;
        gameEntity.isEquipped = _isEquipped;

        return gameEntity;
    }
}

