using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Entitas;

public class DebugView : View, IGameDebugListener
{
    public Text text;

    public void OnDebug(GameEntity entity, string value)
    {
        text.text = value;
    }

    protected override void RegisterListeners(IEntity entity, IContext context)
    {
        var e = (GameEntity)entity;
        e.AddGameDebugListener(this);
    }
}

