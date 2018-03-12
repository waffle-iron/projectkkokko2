using System;
using System.Collections.Generic;
using System.Linq;
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

    protected override IEntity CustomCreate (Contexts contexts)
    {
        var entity = contexts.game.CreateEntity();

        entity.AddNeed(_type);
        entity.AddMax(_max);
        entity.AddDeplete(_depletion);
        entity.AddInterval(_interval);
        entity.AddTrigger(_trigger, false);

        return entity;
    }
}

