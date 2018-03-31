using System;
using System.Collections.Generic;
using Entitas;

public class FoodReturnConfig : UnityEntityConfig
{
    protected override IEntity CustomCreate (Contexts contexts)
    {
        var gameEty = contexts.game.CreateEntity();

        gameEty.isReturn = true;
        gameEty.isCollidable = true;

        return gameEty;
    }
}
