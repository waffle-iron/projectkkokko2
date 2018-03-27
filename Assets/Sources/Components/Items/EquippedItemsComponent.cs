using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using CodeStage.AntiCheat.ObscuredTypes;

//[Entitas.CodeGenerator.SingleEntity]
[Game, Unique]
public sealed class EquippedItemsComponent : IComponent
{
    public List<string> _accessoryList;
    public List<string> _filterInScenes;
}