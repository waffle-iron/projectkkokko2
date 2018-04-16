using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;

//[Entitas.CodeGenerator.SingleEntity]
[Game]
public sealed class SuspendedTimeComponent : IComponent
{
    public DateTime current;
}