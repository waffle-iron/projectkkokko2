using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

//[Entitas.CodeGenerator.SingleEntity]
[Input, Command, Game, Event(false), Event(false, Entitas.CodeGeneration.Attributes.EventType.Removed)]
public sealed class LoadViewsComponent : IComponent
{
    public string[] paths;
    public bool includeSceneObjects;
}