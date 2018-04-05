using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class CollisionSystems : Feature
{
    public CollisionSystems (Contexts contexts) : base("Collision Systems")
    {
        //Add(system here);
        Add(new InputCollisionReactiveSystem(contexts));
        Add(new CommandCollisionReactiveSystem(contexts));

        Add(new ObstacleCollisionDestroyReactiveSystem(contexts));
        //Add(new OnCollisionCleanupSystem(contexts));
    }
}