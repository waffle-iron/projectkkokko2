﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

//[Entitas.CodeGenerator.SingleEntity]
[Game, Input, Command, Event(true)]
public sealed class NeedComponent : IComponent
{
    [PrimaryEntityIndex]
    public NeedType type;
    public ActionType action;
}