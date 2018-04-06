using Entitas;
using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIAction : ScriptableObject
{
    public abstract void Execute (IEntity myDialogEntity, Contexts contexts);
}

