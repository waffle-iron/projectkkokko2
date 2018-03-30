using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

//[Entitas.CodeGenerator.SingleEntity]
[Game, Input, Command, Event(true), Event(true, Entitas.CodeGeneration.Attributes.EventType.Removed)]
public sealed class ConsumingComponent : IComponent
{
    public uint consumerID;
    public uint foodID;
}