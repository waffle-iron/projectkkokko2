using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using UniRx;

public class OsuCircleConfig : UnityEntityConfig
{
    //enter serialized fields here
    [Header("Osu Circle Settings")]
    [SerializeField, Range(0.0f, 1.0f)]
    private float minRange;
    [SerializeField, Range(0.0f, 1.0f)]
    private float maxRange;
    [SerializeField]
    private float duration;


    protected override IEntity CustomCreate (Contexts contexts)
    {
        var gameEty = contexts.game.CreateEntity();

        gameEty.AddAcceptableRange(new Vector2(minRange, maxRange));
        gameEty.AddDuration(duration);
        gameEty.isOsuHitPoint = true;
        gameEty.AddTimer(0f);
        gameEty.AddTimerState(true);

        return gameEty;
    }
}

