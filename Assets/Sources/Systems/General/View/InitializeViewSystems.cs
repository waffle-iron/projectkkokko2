using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class InitializeViewSystems : Feature
{
    public InitializeViewSystems (Contexts contexts) : base("Init View Systems")
    {
        Add(new InputLoadViewsReactiveSystem(contexts));
        Add(new CommandLoadViewsReactiveSystem(contexts));
        Add(new CleanupLoadViewReactiveSystem(contexts));
    }
}