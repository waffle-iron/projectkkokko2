using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class CreateEntitySystems : Feature
{
    public CreateEntitySystems (Contexts contexts) : base("Create Entity Systems")
    {
        //Add(system here);
        Add(new CreateEntityInputReactiveSystem(contexts));
        Add(new CreateEntityCommandReactiveSystem(contexts));
    }
}