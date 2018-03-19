using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

//[Entitas.CodeGenerator.SingleEntity]
[Game, Event(true, Entitas.CodeGeneration.Attributes.EventType.Added), Event(true, Entitas.CodeGeneration.Attributes.EventType.Removed), IgnoreSave]
public sealed class ViewComponent : IComponent
{
    public string name;
    public bool reloadOnSceneChange;
}