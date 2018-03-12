using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using CodeStage.AntiCheat.ObscuredTypes;

//[Entitas.CodeGenerator.SingleEntity]
[Game, Input, Command]
public sealed class MaxAmountComponent : IComponent
{
    public ObscuredInt value;
}