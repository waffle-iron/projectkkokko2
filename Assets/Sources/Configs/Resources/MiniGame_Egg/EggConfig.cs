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
    [SerializeField]
    private float _maxTouchTime;

    protected override IEntity CustomCreate (Contexts contexts)
    {
        var gameEty = contexts.game.CreateEntity();
        gameEty.AddCanThrow(force, minDistance);
        gameEty.AddTouchTimeGap(_maxTouchTime);

        return gameEty;
    }
}

