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
    [SerializeField]
    private bool _canThrowByDefault = false;
    [SerializeField, Tag]
    private string _tag;

    protected override IEntity CustomCreate (Contexts contexts)
    {
        var gameEty = contexts.game.CreateEntity();
        gameEty.AddCanThrow(force, minDistance, _canThrowByDefault);
        gameEty.AddTouchTimeGap(_maxTouchTime);
        gameEty.AddTag(_tag);
        gameEty.isCollidable = true;
        gameEty.isBall = true;

        return gameEty;
    }
}

