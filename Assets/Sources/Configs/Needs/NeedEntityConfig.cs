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

    [Header("Depletion stuff")]
    [SerializeField, Range(0, 10)]
    private int _max;
    [SerializeField, Range(1, 10)]
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

    [Header("Saving stuff")]
    [SerializeField]
    private bool _loadOnStart = false;
    [SerializeField]
    private ObscuredString _saveID;

    protected override IEntity CustomCreate (Contexts contexts)
    {
        var entity = contexts.game.CreateEntity();

        entity.AddNeed(_type);

        if (_max > 0)
        {
            entity.AddMax(_max);
            entity.AddCurrent(_max);
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


        if (_loadOnStart && _saveID.Equals("") == false)
        {
            var load = contexts.input.CreateEntity();
            load.AddTargetEntityID(entity.iD.value);
            load.AddLoad(_saveID, false);
        }

        return entity;
    }
}

