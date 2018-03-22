using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

//[Entitas.CodeGenerator.SingleEntity]
[Game]
public sealed class NotificationMessageComponent : IComponent
{
    public string title;
    public string message;
    public int offset;
}