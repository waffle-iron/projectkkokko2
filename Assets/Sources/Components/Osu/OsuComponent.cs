using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

//[Entitas.CodeGenerator.SingleEntity]
[Game, Unique]
public sealed class OsuComponent : IComponent
{
    public uint maxMisses;
    public uint maxHits;
    public string successEntity;
    public string failedEntity;
}