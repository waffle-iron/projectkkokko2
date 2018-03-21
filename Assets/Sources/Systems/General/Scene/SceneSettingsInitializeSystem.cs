using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class SceneSettingsInitializeSystem : IInitializeSystem
{
    private readonly GameContext _game;

    public SceneSettingsInitializeSystem (Contexts contexts)
    {
        _game = contexts.game;
    }

    public void Initialize ()
    {
        // Initialization code here
    }
}