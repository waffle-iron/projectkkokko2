using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

//[Entitas.CodeGenerator.SingleEntity]
[Game, Input, Command]
public sealed class OnCollisionComponent : IComponent
{
    public uint otherEntityID;
    public CollisionType type;
}