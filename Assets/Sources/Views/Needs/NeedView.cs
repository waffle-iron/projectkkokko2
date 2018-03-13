using System;
using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class NeedView : View, IGameCurrentListener
{
    [SerializeField]
    private Text text;

    public void OnCurrent (GameEntity entity, int amount)
    {
        text.text = amount.ToString();
    }

    protected override void RegisterListeners (IEntity entity, IContext context)
    {
        var gameEntity = (GameEntity)entity;
        gameEntity.AddGameCurrentListener(this);
    }
}

