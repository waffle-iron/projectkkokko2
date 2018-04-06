using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class ThrowSystems : Feature
{
    public ThrowSystems (Contexts contexts) : base("Throw Systems")
    {
        //Add(system here);
        Add(new ThrowAimReactiveSystem(contexts));
        Add(new ThrowStartReactiveSystem(contexts));
    }
}