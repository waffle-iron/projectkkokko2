using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

//[Entitas.CodeGenerator.SingleEntity]
[Game, Input, Command, Event(true), IgnoreSave]
public sealed class AccessoryComponent : IComponent
{
    [PrimaryEntityIndex]
    public string id;
    public AccessoryType type;
}