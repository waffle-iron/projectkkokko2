using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

//[Entitas.CodeGenerator.SingleEntity]
[Game]
public sealed class GridApartmentDataComponent : IComponent
{
    public Dictionary<Vector2, ApartmentItemData> values;
}