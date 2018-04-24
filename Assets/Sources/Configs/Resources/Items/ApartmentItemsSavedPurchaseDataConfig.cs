using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using UniRx;
using CodeStage.AntiCheat.ObscuredTypes;

public class ApartmentItemsSavedPurchaseDataConfig : UnityEntityConfig
{
    //enter serialized fields here
    [Header("Apartment Items Purchased Saved Settings")]
    [SerializeField]
    private ObscuredString[] _initPurchased;
    [SerializeField, SceneName]
    private string[] _sceneToLoad;

    protected override IEntity CustomCreate (Contexts contexts)
    {
        var gameEty = contexts.game.CreateEntity();
        gameEty.isApartmentItemsSavedData = true;
        gameEty.AddSavedModifiedEntitiesConfigIDs(new List<ObscuredString>(_initPurchased));
        gameEty.AddScenes(new List<string>(_sceneToLoad));
        gameEty.isDoNotDestroyOnSceneChange = true;

        return gameEty;
    }
}

