using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

//[Entitas.CodeGenerator.SingleEntity]
[Game, Input, Command]
public sealed class TargetNeedComponent : IComponent
{
    public NeedType type;
}