using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

//[Entitas.CodeGenerator.SingleEntity]
[Game, Event(true), IgnoreSave]
public sealed class ValidPlacementComponent : IComponent
{
    public bool state;
}