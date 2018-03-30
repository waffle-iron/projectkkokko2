﻿using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class FoodConfig : UnityEntityConfig
{
    [Header("Food Settings")]
    [SerializeField]
    private string name;
    [SerializeField]
    private int price;
    [SerializeField]
    [Range(0.00f, 1.00f)]
    private float recovery;
    

    protected override IEntity CustomCreate (Contexts contexts)
    {
        var gameEntity = contexts.game.CreateEntity();

        gameEntity.AddFood(name, recovery);
        gameEntity.AddPrice(price);

        return gameEntity;
    }
}

