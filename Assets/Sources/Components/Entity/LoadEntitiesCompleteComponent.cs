using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

//[Entitas.CodeGenerator.SingleEntity]
[Game, Unique, Event(false), Event(false, Entitas.CodeGeneration.Attributes.EventType.Removed)]
public sealed class LoadEntitiesCompleteComponent : IComponent
{
}