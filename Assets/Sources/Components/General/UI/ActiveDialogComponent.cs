using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

//[Entitas.CodeGenerator.SingleEntity]
[Game, Command, Input, Event(false), Event(false, Entitas.CodeGeneration.Attributes.EventType.Removed), Unique]
public sealed class ActiveDialogComponent : IComponent
{
    public string id;
}