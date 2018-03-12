using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using CodeStage.AntiCheat.ObscuredTypes;

//[Entitas.CodeGenerator.SingleEntity]
[Input, Command]
public sealed class LoadComponent : IComponent
{
    public ObscuredString id;
    public bool createNew;
}