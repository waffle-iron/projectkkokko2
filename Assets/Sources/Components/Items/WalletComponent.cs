using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using CodeStage.AntiCheat.ObscuredTypes;
using Entitas.CodeGeneration.Attributes;

//[Entitas.CodeGenerator.SingleEntity]
[Game, Input, Command, Unique, Event(true)]
public sealed class WalletComponent : IComponent
{
    public int amount;
}