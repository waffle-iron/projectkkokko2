using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class ScoreConfig : UnityEntityConfig
{
    [SerializeField]
    private int _initValue = 0;
    [SerializeField, Tag]
    private string _tag;

    protected override IEntity CustomCreate (Contexts contexts)
    {
        var gameEty = contexts.game.CreateEntity();

        gameEty.AddScore(_initValue);
        gameEty.AddTopScore(_initValue);
        gameEty.AddTag(_tag);

        return gameEty;
    }
}

