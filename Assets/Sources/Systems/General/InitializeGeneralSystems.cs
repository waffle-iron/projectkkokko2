using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class InitializeGeneralSystems : Feature
{
    public InitializeGeneralSystems (Contexts contexts) : base("Init General Systems")
    {
        Add(new GenerateIDSystem(contexts));
        Add(new SceneSettingsInitializeSystem(contexts));
        //Add(new SceneInitializeSystem(contexts));
        //Add(new InitializeSaveSystem(contexts));
        //Add(new InitializePauseSystem(contexts));
        //Add(new InitializeDebugSystem(contexts));
    }
}