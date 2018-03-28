using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class FoodSystems : Feature
{
    public FoodSystems (Contexts contexts) : base("Food Systems")
    {
        //Add(system here);
        Add(new ConsumeInputReactiveSystem(contexts));
        Add(new CommandConsumeReactiveSystem(contexts));
    }
}