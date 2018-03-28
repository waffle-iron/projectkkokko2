using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class PlayerConfig : UnityEntityConfig
{
    [Header("Moveable Settings")]
    [SerializeField]
    private float _speed;

    protected override IEntity CustomCreate (Contexts contexts)
    {
        var gameEty = contexts.game.CreateEntity();

        gameEty.isPlayer = true;
        gameEty.AddMoveable(_speed);

        return gameEty;
    }
}

