﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

//[Entitas.CodeGenerator.SingleEntity]
[Meta, Unique]
public sealed class PauseServiceComponent : IComponent
{
    public IPauseService instance;
}