using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using UniRx;

public class SleepEntityConfig : UnityEntityConfig
{
    //enter serialized fields here
    [Header("Sleep settings")]
    [SerializeField]
    private DurationType sleepDuration;
    [SerializeField]
    private string[] sleepActionEntity;

    protected override IEntity CustomCreate (Contexts contexts)
    {
        var gameEty = contexts.game.CreateEntity();
        gameEty.isSleep = true;
        gameEty.AddTrigger(sleepDuration, false);
        gameEty.AddTimer(0f);
        gameEty.AddTimerState(true);
        gameEty.AddEntity(sleepActionEntity);

        return gameEty;
    }
}

