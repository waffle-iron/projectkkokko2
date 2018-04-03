using System;
using Entitas;
using UnityEngine;

public class SpawnConfig : UnityEntityConfig
{
    [Header("Spawn Settings")]
    [SerializeField]
    private string[] entities;
    [SerializeField]
    private DurationType interval;

    protected override IEntity CustomCreate (Contexts contexts)
    {
        var gameEty = contexts.game.CreateEntity();

        gameEty.AddSpawn(entities, interval);

        return gameEty;
    }
}

