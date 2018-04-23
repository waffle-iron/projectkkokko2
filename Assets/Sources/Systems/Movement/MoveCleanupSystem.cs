using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class MoveCleanupSystem : ICleanupSystem
{
    private readonly IGroup<GameEntity> _movings;
    private readonly IGroup<GameEntity> _teleport;
    private List<GameEntity> _buffer;
    private List<GameEntity> _teleportBuffer;

    public MoveCleanupSystem (Contexts contexts)
    {
        _movings = contexts.game.GetGroup(GameMatcher.Moving);
        _teleport = contexts.game.GetGroup(GameMatcher.Teleport);
        _buffer = new List<GameEntity>();
        _teleportBuffer = new List<GameEntity>();
    }

    public void Cleanup ()
    {
        // Initialization code here
        foreach (var move in _movings.GetEntities(_buffer))
        {
            move.isMoving = false;
        }

        foreach (var tele in _teleport.GetEntities(_teleportBuffer))
        {
            tele.isTeleport = false;
        }
    }
}