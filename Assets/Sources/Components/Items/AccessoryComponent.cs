using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

//[Entitas.CodeGenerator.SingleEntity]
[Game, Input, Command]
public sealed class AccessoryComponent : IComponent
{
    [PrimaryEntityIndex]
    public AccessoryID id;
    public AccessoryType type;
}