using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

//[Entitas.CodeGenerator.SingleEntity]
[Input, Command, Game, IgnoreSave]
public sealed class TargetEntityIDComponent : IComponent
{
    public uint value;
}