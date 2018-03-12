﻿using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class DebugFeature : Feature
{
    public DebugFeature(Contexts contexts) : base("Debug Systems")
    {
        //Add(system here);
        Add(new InitializeDebugSystem(contexts));
        Add(new InputDebugReactiveSystem(contexts));
        Add(new CommandDebugReactiveSystem(contexts));
    }
}