using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class DebugSystems : Feature
{
    public DebugSystems(Contexts contexts) : base("Debug Systems")
    {
        //Add(system here);
        Add(new InputDebugReactiveSystem(contexts));
        Add(new CommandDebugReactiveSystem(contexts));
    }
}