using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class FoodInteractableConfig : UnityEntityConfig
{
    [SerializeField]
    private float speed;

    protected override IEntity CustomCreate (Contexts contexts)
    {
        var gameEty = contexts.game.CreateEntity();
        gameEty.isCollidable = true;
        gameEty.AddMoveable(speed);

        return gameEty;
    }
}

