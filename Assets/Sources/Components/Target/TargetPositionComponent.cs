﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

//[Entitas.CodeGenerator.SingleEntity]
[Game, Command, Input]
public sealed class TargetPositionComponent : IComponent
{
    public Vector3 value;
}