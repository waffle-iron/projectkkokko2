using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class ReturnableSystems : Feature
{
    public ReturnableSystems (Contexts contexts) : base("Returnable Systems")
    {
        //Add(system here);
        Add(new ReturnReactiveSystem(contexts));
        Add(new CollisionReturnReactiveSystem(contexts));
    }
}