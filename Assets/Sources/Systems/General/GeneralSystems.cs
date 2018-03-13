using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class GeneralSystems : Feature
{
    public GeneralSystems (Contexts contexts) : base("General Systems")
    {
        Add(new CreateEntitySystems(contexts));
        Add(new AddViewReactiveSystem(contexts));
        Add(new SceneSystems(contexts));
        Add(new SaveSystems(contexts));
        Add(new PauseSystems(contexts));
        Add(new DebugSystems(contexts));
        Add(new TimerSystems(contexts));
        Add(new AnimationSystems(contexts));

        //Cleanup
        Add(new DestroySystem(contexts));
    }
}