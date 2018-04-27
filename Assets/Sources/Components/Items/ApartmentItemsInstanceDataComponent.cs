using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

//[Entitas.CodeGenerator.SingleEntity]
[Game, Unique]
public sealed class ApartmentItemsInstanceDataComponent : IComponent
{
    //Dictionary<entityCfgId, Dictionary<AptItemID+Index, Position>>
    public Dictionary<string, Dictionary<string, Vector3>> data;
}