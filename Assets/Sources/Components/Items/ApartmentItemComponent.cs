using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

//[Entitas.CodeGenerator.SingleEntity]
[Game, IgnoreSave]
public sealed class ApartmentItemComponent : IComponent
{
    [EntityIndex]
    public ApartmentItemData data;
}