using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class PauseSystems : Feature
{
    public PauseSystems (Contexts contexts) : base("Pause Systems")
    {
        Add(new InputPauseSystem(contexts));

        Add(new CommandPauseReactiveSystem(contexts));

        Add(new ForceUnpauseDialogReactiveSystem(contexts));
    }
}