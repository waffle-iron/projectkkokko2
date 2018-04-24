using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using CodeStage.AntiCheat.ObscuredTypes;

//[Entitas.CodeGenerator.SingleEntity]
[Game]
public sealed class SavedModifiedEntitiesConfigIDsComponent : IComponent
{
    public List<ObscuredString> ids;
}