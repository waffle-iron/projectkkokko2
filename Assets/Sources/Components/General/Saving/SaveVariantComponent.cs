using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using CodeStage.AntiCheat.ObscuredTypes;

//[Entitas.CodeGenerator.SingleEntity]
[Input, Command]
public sealed class SaveVariantComponent : IComponent
{
    public ObscuredString suffix;
}