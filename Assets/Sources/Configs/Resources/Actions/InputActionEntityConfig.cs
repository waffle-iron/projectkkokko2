using System;
using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine;

public class InputActionEntityConfig : UnityEntityConfig
{
    [Header("Action")]
    [SerializeField]
    private ActionType _type;

    [Header("For actions that target a need")]
    [SerializeField]
    private NeedType _targetNeed;

    [SerializeField]
    private int restoreAmount = 0;

    protected override IEntity CustomCreate (Contexts contexts)
    {
        var inputEntity = contexts.input.CreateEntity();

        inputEntity.AddAction(_type);

        if (_targetNeed != NeedType.NONE)
        {
            inputEntity.AddTargetNeed(_targetNeed);
            inputEntity.AddReset(restoreAmount);
            inputEntity.AddDelayDestroy(1);
        }

        return inputEntity;
    }
}

