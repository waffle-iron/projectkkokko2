using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using CodeStage.AntiCheat.ObscuredTypes;

//[Entitas.CodeGenerator.SingleEntity]
[Game, IgnoreSave]
public sealed class SaveIDComponent : IComponent
{
    public ObscuredString value;
}