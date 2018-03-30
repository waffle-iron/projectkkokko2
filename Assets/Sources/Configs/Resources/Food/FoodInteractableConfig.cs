using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class FoodInteractableConfig : UnityEntityConfig
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private DurationType eatTime;

    protected override IEntity CustomCreate (Contexts contexts)
    {
        var gameEty = contexts.game.CreateEntity();
        gameEty.isCollidable = true;
        gameEty.AddMoveable(speed);
        gameEty.isTargetable = true;
        gameEty.AddTimer(0f);
        gameEty.AddTrigger(eatTime, false);

        return gameEty;
    }
}

