using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class OnCollisionCleanupSystem : ICleanupSystem
{
    private readonly IGroup<GameEntity> _onCollision;
    private List<GameEntity> _buffer;


    public OnCollisionCleanupSystem (Contexts contexts)
    {
        _onCollision = contexts.game.GetGroup(GameMatcher.OnCollision);
        _buffer = new List<GameEntity>();
    }

    public void Cleanup ()
    {
        // Initialization code here
        foreach (var e in _onCollision.GetEntities(_buffer))
        {
            e.RemoveOnCollision();
        }
    }
}