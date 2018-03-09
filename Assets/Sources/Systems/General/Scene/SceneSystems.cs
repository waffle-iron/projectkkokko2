using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class SceneSystems : Feature
{
    public SceneSystems (Contexts contexts) : base("Scene Systems")
    {
        //Add(system here);
        //Inputs
        Add(new InputLoadSceneSystem(contexts));
        Add(new InputLoadSceneCompleteSystem(contexts));

        //Commands
        Add(new CommandLoadSceneSystem(contexts));
        Add(new CommandLoadSceneCompleteSystem(contexts));

    }
}