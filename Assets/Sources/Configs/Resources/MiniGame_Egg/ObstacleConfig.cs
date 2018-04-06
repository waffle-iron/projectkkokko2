using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using UniRx;

public class ObstacleConfig : UnityEntityConfig
{
    //enter serialized fields here
    [Header("Obstacle Settings")]
    [SerializeField, Tag]
    private string _tag;
    [SerializeField]
    private float _speed;
    [SerializeField, Tag]
    private string[] _targets;

    protected override IEntity CustomCreate (Contexts contexts)
    {
        var gameEty = contexts.game.CreateEntity();

        gameEty.AddTag(_tag);
        gameEty.isCollidable = true;
        gameEty.AddMoveable(_speed);
        gameEty.AddTargetTag(_targets);
        gameEty.isObstacle = true;

        return gameEty;
    }
}

