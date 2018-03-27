﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

//[Entitas.CodeGenerator.SingleEntity]
[Game, Input, Command]
public sealed class TargetMoveComponent : IComponent
{
    public Vector3 position;
}