using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class MoveCleanupSystem : ICleanupSystem
{
    private readonly IGroup<GameEntity> _movings;
    private List<GameEntity> _buffer;

    public MoveCleanupSystem (Contexts contexts)
    {
        _movings = contexts.game.GetGroup(GameMatcher.Moving);
        _buffer = new List<GameEntity>();
    }

    public void Cleanup ()
    {
        // Initialization code here
        foreach (var move in _movings.GetEntities(_buffer))
        {
            move.isMoving = false;
        }
    }
}