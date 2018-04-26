using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using UniRx;

public class ApartmentInstanceDataConfig : UnityEntityConfig
{
    //enter serialized fields here
    [Header("Apartment Instance Data Settings")]
    [SerializeField, SceneName]
    private List<string> _scenesToLoad;

    protected override IEntity CustomCreate (Contexts contexts)
    {
        var gameEty = contexts.game.CreateEntity();
        gameEty.AddApartmentItemsInstanceData(new Dictionary<string, Dictionary<string, Vector3>>());
        gameEty.AddScenes(_scenesToLoad);
        gameEty.isDoNotDestroyOnSceneChange = true;
        return gameEty;
    }
}

