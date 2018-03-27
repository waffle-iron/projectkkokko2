using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

//[Entitas.CodeGenerator.SingleEntity]
public sealed class OnCollisionComponent : IComponent
{
    public uint otherEntityID;
    public CollisionType type;
}