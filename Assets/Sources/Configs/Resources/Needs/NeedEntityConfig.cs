using System;
using System.Collections.Generic;
using System.Linq;
using CodeStage.AntiCheat.ObscuredTypes;
using Entitas;
using UnityEngine;

public class NeedEntityConfig : UnityEntityConfig
{
    [Header("Need ID")]
    [SerializeField]
    private NeedType _type;
    [SerializeField]
    private ActionType _matchingAction;

    [Header("Depletion stuff")]
    [SerializeField, Range(0, 10)]
    private int _max;
    [SerializeField, Range(0, 10)]
    private int _minRequirement;
    [SerializeField, Range(0, 10)]
    private int _depletion;
    [SerializeField]
    private NeedType _target;

    [Header("Timer stuff")]
    [SerializeField]
    private DurationType _interval;
    [SerializeField]
    private DurationType _trigger;
    [SerializeField]
    private bool _runOnStart = false;
    [SerializeField]
    private bool _isFastForwardOnStart = false;

    protected override IEntity CustomCreate (Contexts contexts)
    {
        var entity = contexts.game.CreateEntity();

        entity.AddNeed(_type, _matchingAction);

        if (_max > 0)
        {
            entity.AddMax(_max);
            entity.AddCurrent(_max);
            entity.AddMinRequirement(_minRequirement);
        }

        if (_target != NeedType.NONE)
        {
            entity.AddTargetNeed(_target);
            entity.AddDeplete(_depletion);
            entity.AddInterval(_interval);
            entity.AddTrigger(_trigger, false);
            entity.AddTimer(0f);
            entity.AddTimerState(_runOnStart);
        }
        if (_isFastForwardOnStart)
        {
            entity.isFastForward = true;
        }

        return entity;
    }
}

