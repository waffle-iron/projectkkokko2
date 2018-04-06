using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class SpawnSystems : Feature
{
    public SpawnSystems (Contexts contexts) : base("Spawn Systems")
    {
        //Add(system here);
        Add(new SpawnReactiveSystem(contexts));
    }
}