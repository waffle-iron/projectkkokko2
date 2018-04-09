using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class PlayerConfig : UnityEntityConfig
{
    [Header("Player Setting")]
    [SerializeField, Tag]
    private string _tag;

    [Header("Moveable Settings")]
    [SerializeField]
    private float _speed;

    [Header("Target Settings")]
    [SerializeField]
    private float _stopDistance;

    protected override IEntity CustomCreate (Contexts contexts)
    {
        var gameEty = contexts.game.CreateEntity();

        gameEty.isPlayer = true;
        gameEty.AddMoveable(_speed);
        gameEty.AddFollowTarget(_stopDistance);
        gameEty.isCollidable = true;
        gameEty.AddTag(_tag);

        return gameEty;
    }
}

