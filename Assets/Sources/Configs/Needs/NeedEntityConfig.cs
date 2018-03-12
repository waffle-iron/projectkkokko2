using System;
using System.Collections.Generic;
using System.Linq;
using CodeStage.AntiCheat.ObscuredTypes;
using Entitas;
using UnityEngine;

public class NeedEntityConfig : UnityEntityConfig
{
    [SerializeField]
    private NeedType _type;
    [SerializeField, Range(1, 10)]
    private int _max;
    [SerializeField, Range(1, 10)]
    private int _depletion;
    [SerializeField]
    private DurationType _interval;
    [SerializeField]
    private DurationType _trigger;
    [SerializeField]
    private bool _runOnStart = false;
    [SerializeField]
    private bool _loadOnStart = false;
    [SerializeField]
    private ObscuredString _saveID;

    protected override IEntity CustomCreate (Contexts contexts)
    {
        var entity = contexts.game.CreateEntity();

        entity.AddNeed(_type);
        entity.AddMax(_max);
        entity.AddDeplete(_depletion);
        entity.AddInterval(_interval);
        entity.AddTrigger(_trigger, false);
        entity.AddTimer(0f);
        entity.AddTimerState(_runOnStart);
        
        if (_loadOnStart && _saveID.Equals("") == false)
        {
            var load = contexts.input.CreateEntity();
            load.AddTargetEntityID(entity.iD.value);
            load.AddLoad(_saveID, false);
        }

        return entity;
    }
}

