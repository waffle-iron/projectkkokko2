using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

//[Entitas.CodeGenerator.SingleEntity]
[Game, Command, Input, IgnoreSave]
public sealed class DelayDestroyComponent : IComponent
{
    public uint frames;
}