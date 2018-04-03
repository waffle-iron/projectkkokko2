using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using UniRx;

public class ScoreHoopConfig : UnityEntityConfig
{
    //enter serialized fields here
    [Header("Score Hoop Settings")]
    [SerializeField]
    private int scoreValue;
    [SerializeField, Tag]
    private string _tag;
    [SerializeField, Tag]
    private string[] targetTags;

    protected override IEntity CustomCreate (Contexts contexts)
    {
        var gameEty = contexts.game.CreateEntity();
        gameEty.AddTag(_tag);
        gameEty.AddChangeScore(scoreValue, OperationType.ADD);
        gameEty.isCollidable = true;
        gameEty.AddTargetTag(targetTags);

        return gameEty;
    }
}

