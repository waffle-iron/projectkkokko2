using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class GameStateConfig : UnityEntityConfig
{
    [SerializeField]
    private MainGameState state;
    [SerializeField]
    private bool _isInput = false;

    protected override IEntity CustomCreate (Contexts contexts)
    {
        if (_isInput == false)
        {
            var gameEty = contexts.game.CreateEntity();
            gameEty.AddGameState(new GameState(state));
            //gameEty.isDoNotDestroyOnSceneChange = true;

            return gameEty;
        }
        else
        {
            var inputEty = contexts.input.CreateEntity();
            inputEty.AddGameState(new GameState(state));
            return inputEty;
        }
    }
}

