using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

//[Entitas.CodeGenerator.SingleEntity]
[Game, Event(true)]
public sealed class AcceptableRangeComponent : IComponent
{
    public Vector2 values;
}