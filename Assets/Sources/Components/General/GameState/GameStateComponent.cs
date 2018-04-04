using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using System;

//[Entitas.CodeGenerator.SingleEntity]
[Game, Command, Input, Unique, Event(false)]
public sealed class GameStateComponent : IComponent
{
    public GameState current;
}