﻿using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class TouchSystems : Feature
{
    public TouchSystems (Contexts contexts) : base("Touch Systems")
    {
        //Add(system here);
        Add(new TouchPhaseInputReactiveSystem(contexts));
        Add(new TouchPhaseCommandReactiveSystem(contexts));
    }
}