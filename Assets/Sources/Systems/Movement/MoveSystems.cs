using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class MoveSystems : Feature
{
    public MoveSystems (Contexts contexts) : base("Move Systems")
    {
        //Add(system here);
        Add(new InputMoveReactiveSystem(contexts));

        Add(new CommandMoveReactiveSystem(contexts));

        Add(new MoveCleanupSystem(contexts));
    }
}