using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class ActionSystems : Feature
{
    public ActionSystems (Contexts contexts) : base("Action systems")
    {
        //Add(system here);
        Add(new ActionInitializeSystem(contexts));
        Add(new InputActionReactiveSystem(contexts));
    }
}