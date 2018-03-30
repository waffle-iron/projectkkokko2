using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

//[Entitas.CodeGenerator.SingleEntity]
[Game, Command, Input, IgnoreSave]
public sealed class IDComponent : IComponent
{
    [PrimaryEntityIndex]
    public uint value;
}