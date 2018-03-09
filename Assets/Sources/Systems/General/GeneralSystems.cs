using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class GeneralSystems : Feature
{
    public GeneralSystems (Contexts contexts) : base("General Systems")
    {
        //Initialize
        Add(new ViewReactiveSystem(contexts));
        Add(new GenerateIDSystem(contexts));
        Add(new SceneSystems(contexts));

        //Cleanup
        Add(new DestroySystem(contexts));
    }
}