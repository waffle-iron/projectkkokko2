using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class SaveSystems : Feature
{
    public SaveSystems (Contexts contexts) : base("Save Systems")
    {
        Add(new InitializeSaveSystem(contexts));
        Add(new InputSaveLoadEntityReactiveSystem(contexts));
        Add(new CommandSaveLoadReactiveSystem(contexts));
        Add(new SaveLoadCleanupSystem(contexts));
    }
}