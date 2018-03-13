using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class NeedSystems : Feature
{
    public NeedSystems (Contexts contexts) : base("Need Systems")
    {
        //Add(system here);
        Add(new NeedInitializeSystem(contexts));

        Add(new NeedInputReactiveSystem(contexts));
        Add(new NeedCommandReactiveSystem(contexts));

        Add(new NeedTriggerReactiveSystem(contexts));
        Add(new NeedDeductReactiveSystem(contexts));
    }
}