using System;
using Entitas;
using UnityEngine;

public class SpawnConfig : UnityEntityConfig
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

        return gameEty;
    }
}

