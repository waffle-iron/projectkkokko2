using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

//[Entitas.CodeGenerator.SingleEntity]
[Input, Command]
public sealed class GridCollisionComponent : IComponent
{
    public string gridID;
    public HashSet<GridSquare> indexes;
}