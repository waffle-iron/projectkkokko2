using System;
using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine;

public class ActionEntityConfig : UnityEntityConfig
{
    [Header("Action")]
    [SerializeField]
    private ActionType _type;

    [Header("For actions that target a need")]
    [SerializeField]
    private NeedType _targetNeed;

    protected override IEntity CustomCreate (Contexts contexts)
    {
        var gameEntity = contexts.game.CreateEntity();
        if (_targetNeed != NeedType.NONE)
        {
            gameEntity.AddTargetNeed(_targetNeed);
        }

        return gameEntity;
    }
}

