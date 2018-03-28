using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class GameStateSystems : Feature
{
    public GameStateSystems (Contexts contexts) : base("Game State Systems")
    {
        //Add(system here);
        Add(new GameStateInputReactiveSystem(contexts));
        Add(new GameStateCommandReactiveSystem(contexts));
    }
}