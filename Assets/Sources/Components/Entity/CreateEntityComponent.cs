using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

//[Entitas.CodeGenerator.SingleEntity]
[Input, Command]
public sealed class CreateEntityComponent : IComponent
{
    public string configName;
}