using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

//[Entitas.CodeGenerator.SingleEntity]
[Meta, Unique]
public sealed class ViewServiceComponent : IComponent
{
    public IViewService instance;
    public bool isInitialized;
}