using System;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class EggConfig : UnityEntityConfig
{
    [Header("Egg Settings")]
    [SerializeField]
    private float force;
    [SerializeField]
    private float minDistance;

    protected override IEntity CustomCreate (Contexts contexts)
    {
        var gameEty = contexts.game.CreateEntity();
        gameEty.AddCanThrow(force, minDistance);

        return gameEty;
    }
}

