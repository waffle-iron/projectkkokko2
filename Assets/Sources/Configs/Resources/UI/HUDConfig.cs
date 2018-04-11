using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using UniRx;

public class HUDConfig : UnityEntityConfig
{
    //enter serialized fields here
    [Header("Hud Settings")]
    [SerializeField]
    private bool defaultState = true;

    protected override IEntity CustomCreate (Contexts contexts)
    {
        var gameEty = contexts.game.CreateEntity();
        gameEty.AddHud(defaultState);
        gameEty.isDoNotDestroyOnSceneChange = true;

        return gameEty;
    }
}

