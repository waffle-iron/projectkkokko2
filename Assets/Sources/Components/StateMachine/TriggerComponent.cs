using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

//[Entitas.CodeGenerator.SingleEntity]
[Game]
public sealed class GameStateTriggerComponent : IComponent
{
    public GameState current;
    public ITrigger[] triggers;
    public GameState next;
}