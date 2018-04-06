using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using UniRx;

public class MiniGameEggStateConfig : UnityEntityConfig
{
    //enter serialized fields here
    [Header("Game State")]
    [SerializeField]
    private MiniGameEggState _startState;

    protected override IEntity CustomCreate (Contexts contexts)
    {
        var gameEty = contexts.game.CreateEntity();

        gameEty.AddGameState(new GameState((int)_startState, typeof(MiniGameEggState)));

        return gameEty;
    }
}

