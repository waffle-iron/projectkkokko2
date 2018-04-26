using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

//[Entitas.CodeGenerator.SingleEntity]
[Game, IgnoreSave]
public sealed class EntityConfigComponent : IComponent
{
    public string name;
}