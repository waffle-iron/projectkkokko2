using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class PauseSystems : Feature
{
    public PauseSystems (Contexts contexts) : base("Pause Systems")
    {
        Add(new InputPauseReactiveSystem(contexts));
        Add(new CommandPauseReactiveSystem(contexts));
    }
}