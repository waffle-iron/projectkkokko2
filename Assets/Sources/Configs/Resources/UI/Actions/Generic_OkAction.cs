using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class Generic_OkAction : UIAction
{
    public override void Execute (IEntity dialogEntity, Contexts contexts)
    {
        var inputEty = contexts.input.CreateEntity();
        var _id = ((GameEntity)dialogEntity).dialog.id;
        inputEty.AddDeactivateDialog(_id);
        inputEty.AddDelayDestroy(1);
    }
}

