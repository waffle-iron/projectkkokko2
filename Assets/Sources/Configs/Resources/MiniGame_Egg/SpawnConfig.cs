using System;
using Entitas;
using UnityEngine;

public class SpawnConfig : UnityEntityConfig
{
    [Header("Spawn Settings")]
    [SerializeField]
    private string[] entities;
    [SerializeField]
    private DurationType minInterval;
    [SerializeField]
    private DurationType maxInterval;

    protected override IEntity CustomCreate (Contexts contexts)
    {
        var gameEty = contexts.game.CreateEntity();

        gameEty.AddSpawn(entities, minInterval, maxInterval);
        gameEty.AddTimer(0f);
        gameEty.AddTimerState(true);
        return gameEty;
    }
}

