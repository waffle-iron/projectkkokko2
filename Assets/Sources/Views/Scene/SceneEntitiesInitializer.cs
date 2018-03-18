using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class SceneEntitiesInitializer : MonoBehaviour
{
    [SerializeField]
    private EntityCfgID[] entities;

    private InputContext _input;
    private GameContext _game;
    private bool isInitialized = false;

    private void Awake ()
    {
        _input = Contexts.sharedInstance.input;
        _game = Contexts.sharedInstance.game;
    }

    // Use this for initialization
    void Update ()
    {
        if (_game.isLoadSceneComplete && _game.isLoadedViewsComplete && isInitialized == false)
        {
            foreach (var ety in entities)
            {
                _input.CreateEntity().AddCreateEntity(ety);
            }

            isInitialized = true;
        }
    }
}
