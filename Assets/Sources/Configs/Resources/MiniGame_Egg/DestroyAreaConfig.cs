using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using UniRx;

public class DestroyAreaConfig : UnityEntityConfig
{
    //enter serialized fields here

    protected override IEntity CustomCreate (Contexts contexts)
    {
        var gameEty = contexts.game.CreateEntity();
        gameEty.isCollidable = true;
        gameEty.isCanDestroyOther = true;

        return gameEty;
    }
}

