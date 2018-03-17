using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using CodeStage.AntiCheat.ObscuredTypes;

//[Entitas.CodeGenerator.SingleEntity]
[Game, Input, Command, Event(true), IgnoreSave]
public sealed class PriceComponent : IComponent
{
    public ObscuredInt amount;
}