using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

//[Entitas.CodeGenerator.SingleEntity]
[Game, Input, Command, Event(true)]
public sealed class TargetMoveComponent : IComponent
{
    public Vector3 position;
    public float stopDistance;
}