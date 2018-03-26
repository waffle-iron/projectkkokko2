using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

//[Entitas.CodeGenerator.SingleEntity]
[Game, Command, Input, Event(true)]
public sealed class PrePurchaseComponent : IComponent
{
}