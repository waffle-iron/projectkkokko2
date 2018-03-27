using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class SwitchSceneConfig : UnityEntityConfig
{
    [SceneName, SerializeField]
    private string _targetScene;

    protected override IEntity CustomCreate (Contexts contexts)
    {
        var inputEntity = contexts.input.CreateEntity();
        inputEntity.AddLoadScene(_targetScene);
        return inputEntity;
    }
}
