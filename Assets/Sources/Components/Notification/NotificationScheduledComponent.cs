using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

//[Entitas.CodeGenerator.SingleEntity]
[Game]
public sealed class NotificationScheduledComponent : IComponent
{
    public int seconds;
    public int id;
}