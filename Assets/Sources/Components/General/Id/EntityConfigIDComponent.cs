﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

//[Entitas.CodeGenerator.SingleEntity]
[Game, Command, Input]
public sealed class EntityConfigIDComponent : IComponent
{
    [EntityIndex]
    public EntityCfgID value;
}