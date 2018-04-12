using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using UniRx;

public class OsuManagerConfig : UnityEntityConfig
{
    //enter serialized fields here
    [Header("Osu Manager Settings")]
    [SerializeField]
    private uint numCircles = 1;
    [SerializeField]
    private uint numTolerableMisses = 1;
    [SerializeField]
    private string fitnessRestoreEntity;
    [SerializeField]
    private string failedFitnessEntity;

    [Header("Spawn Settings")]
    [SerializeField]
    private string osuCircleEntity;
    [SerializeField]
    private DurationType minTime;
    [SerializeField]
    private DurationType maxTime;


    protected override IEntity CustomCreate (Contexts contexts)
    {
        var gameEty = contexts.game.CreateEntity();

        gameEty.AddOsu(numTolerableMisses, numCircles, fitnessRestoreEntity, failedFitnessEntity);
        gameEty.AddHit(0);
        gameEty.AddMiss(0);
        gameEty.AddSpawn(new string[] { osuCircleEntity }, false, minTime, maxTime);
        gameEty.AddSpawnCounter(0);
        gameEty.AddSpawnLimit(numCircles);
        gameEty.AddTimer(0f);
        gameEty.AddTimerState(true);

        return gameEty;
    }
}

