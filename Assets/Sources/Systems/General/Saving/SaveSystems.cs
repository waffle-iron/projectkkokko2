using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class SaveSystems : Feature
{
    public SaveSystems (Contexts contexts) : base("Save Systems")
    {
        Add(new InputSaveLoadEntityReactiveSystem(contexts));
        Add(new InputLoadEntitySystem(contexts));

        Add(new CommandSaveLoadReactiveSystem(contexts));
        Add(new CommandLoadReactiveSystem(contexts));

        Add(new SaveLoadCleanupSystem(contexts));

    }
}