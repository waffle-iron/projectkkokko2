using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

//[Entitas.CodeGenerator.SingleEntity]
[Game, Event(false), Event(false, Entitas.CodeGeneration.Attributes.EventType.Removed), IgnoreSave]
public sealed class LoadingComponent : IComponent
{
}