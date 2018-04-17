using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

//[Entitas.CodeGenerator.SingleEntity]
[Game, Event(true), Event(true, Entitas.CodeGeneration.Attributes.EventType.Removed)]
public sealed class AssignedToGridComponent : IComponent
{
    public string id;
}