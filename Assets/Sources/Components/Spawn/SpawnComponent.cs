using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

//[Entitas.CodeGenerator.SingleEntity]
[Game]
public sealed class SpawnComponent : IComponent
{
    public string[] entityID;
    public DurationType minInterval;
    public DurationType maxInterval;
}