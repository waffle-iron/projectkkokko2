using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using UniRx;

public class CoinConfig : UnityEntityConfig
{
    //enter serialized fields here
    [Header("Coin Settings")]
    [SerializeField]
    private int value;
    [SerializeField]
    private OperationType type;
    [SerializeField, Tag]
    private string _tag;
    [SerializeField, Tag]
    private string[] _targetTags;

    protected override IEntity CustomCreate (Contexts contexts)
    {
        var gameEty = contexts.game.CreateEntity();

        gameEty.AddCoin(value, type);
        gameEty.isCollidable = true;
        gameEty.AddTag(_tag);
        gameEty.AddTargetTag(_targetTags);

        return gameEty;
    }
}

