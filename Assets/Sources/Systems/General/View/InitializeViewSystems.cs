using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class InitializeViewSystems : Feature
{
    public InitializeViewSystems (Contexts contexts) : base("Init View Systems")
    {
        Add(new ReloadViewsOnSceneLoadCompleteReactiveSystem(contexts));

        //Add(new InputLoadViewsReactiveSystem(contexts));
        //Add(new CommandLoadViewsReactiveSystem(contexts));
    }
}