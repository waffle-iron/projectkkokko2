﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

//[Entitas.CodeGenerator.SingleEntity]
[Game, Command, Input]
public sealed class NeedRecoveryModifierComponent : IComponent
{
    public float value;
}