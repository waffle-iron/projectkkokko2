using System;
using Entitas;
using UnityEngine;

public class Generic_Change_Scene_Action : UIAction
{
    [SerializeField, SceneName]
    private string _targetScene;

    public override void Execute (IEntity myDialogEntity, Contexts contexts)
    {
        var input = contexts.input.CreateEntity();
        input.AddLoadScene(_targetScene);
    }
}

