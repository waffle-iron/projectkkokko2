using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

//[Entitas.CodeGenerator.SingleEntity]
[Game, Input, Command, Event(false), Event(false, Entitas.CodeGeneration.Attributes.EventType.Removed), Unique]
public sealed class PauseComponent : IComponent
{
    public bool state;
}