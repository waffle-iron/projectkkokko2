using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class NeedNotificationConfig : UnityEntityConfig
{
    [Header("Need Notification Data")]
    [SerializeField]
    private NeedType _type;
    [SerializeField]
    private string _title;
    [SerializeField]
    private string _message;
    [SerializeField]
    private int _offset;

    protected override IEntity CustomCreate (Contexts contexts)
    {
        var gameEntity = contexts.game.CreateEntity();
        gameEntity.AddTargetNeed(_type);
        gameEntity.AddNotificationMessage(_title, _message, _offset);
        return gameEntity;
    }
}

