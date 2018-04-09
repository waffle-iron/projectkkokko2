﻿using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class SoapSystems : Feature
{
    public SoapSystems (Contexts contexts) : base("Soap Hygiene Systems")
    {
        //Add(system here);
        Add(new WipeReactiveSystem(contexts));
        Add(new WipeCompleteReactiveSystem(contexts));
        Add(new LimitSoapExecuteSystem(contexts));
    }
}