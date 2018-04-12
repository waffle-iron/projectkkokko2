using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class UISystems : Feature
{
    public UISystems (Contexts contexts) : base("UI Systems")
    {
        //Add(system here);
        Add(new ChangeHudInputReactiveSystem(contexts));
        Add(new ChangeHudCommandReactiveSystem(contexts));

        Add(new ActivateDialogInputSystem(contexts));
        Add(new DeactiveDialogInputReactiveSystem(contexts));

        Add(new ActivateDialogCommandSystem(contexts));
        Add(new DeactiveDialogCommandReactiveSystem(contexts));
    }
}