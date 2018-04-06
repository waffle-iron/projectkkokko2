using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class MiniGame_Egg_NewState_Action : UIAction
{
    [SerializeField]
    MiniGameEggState _newState;

    public override void Execute (IEntity entity, Contexts contexts)
    {
        var inputEty = contexts.input.CreateEntity();
        inputEty.AddGameState(new GameState(_newState));
        inputEty.AddDeactivateDialog(((GameEntity)entity).dialog.id);
    }
}

