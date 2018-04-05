using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using UniRx;

public class SpawnCoinConfig : UnityEntityConfig
{
    [Header("Spawn Settings")]
    [SerializeField, Tag]
    private string _tag;
    [SerializeField]
    private string[] entities;
    [SerializeField]
    private bool isRandomized = false;
    [SerializeField]
    private DurationType minInterval;
    [SerializeField]
    private DurationType maxInterval;

    protected override IEntity CustomCreate (Contexts contexts)
    {
        var gameEty = contexts.game.CreateEntity();

        gameEty.AddSpawn(entities, isRandomized, minInterval, maxInterval);
        gameEty.AddTimer(0f);
        gameEty.AddTimerState(false);
        gameEty.AddTag(_tag);
        gameEty.AddScore(0);
        gameEty.AddCoin(1, OperationType.ADD);

        return gameEty;
    }
}

