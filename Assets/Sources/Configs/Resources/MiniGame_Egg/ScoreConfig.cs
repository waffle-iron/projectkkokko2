using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class ScoreConfig : UnityEntityConfig
{
    [SerializeField]
    private int _initValue = 0;

    protected override IEntity CustomCreate (Contexts contexts)
    {
        var gameEty = contexts.game.CreateEntity();

        gameEty.AddScore(_initValue);

        return gameEty;
    }
}

