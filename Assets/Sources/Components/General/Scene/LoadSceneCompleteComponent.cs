﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

//[Entitas.CodeGenerator.SingleEntity]
[Input, Command, Game, Unique]
public sealed class LoadSceneCompleteComponent : IComponent
{
}