using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

//[Entitas.CodeGenerator.SingleEntity]
[Game]
public sealed class DialogComponent : IComponent
{
    [PrimaryEntityIndex]
    public string id;
    [EntityIndex]
    public DialogType type;
    public string title;
    public string message;
    public bool isPause;
}