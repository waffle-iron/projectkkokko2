using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using UniRx;

public class PoopEntityConfig : UnityEntityConfig
{
    //enter serialized fields here
    [Header("Poop Settings")]
    [SerializeField]
    private DurationType deduction;
    [SerializeField]
    private DurationType interval;

    protected override IEntity CustomCreate (Contexts contexts)
    {
        var gameEty = contexts.game.CreateEntity();
        gameEty.AddPoop(deduction);
        gameEty.isCollidable = true;
        gameEty.isReturnable = true;
        gameEty.AddMoveable(1f);
        gameEty.AddInterval(interval);
        gameEty.AddTimer(0f);
        gameEty.AddTimerState(false);
        return gameEty;
    }
}

