using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class ViewCleanupAddedSystem : ICleanupSystem
{
    private IGroup<GameEntity> _added;
    private List<GameEntity> _buffer;

    public ViewCleanupAddedSystem (Contexts contexts)
    {
        _added = contexts.game.GetGroup(GameMatcher.AddedView);
        _buffer = new List<GameEntity>();
    }

    public void Cleanup ()
    {
        // Initialization code here
        foreach (var e in _added.GetEntities(_buffer))
        {
            e.isAddedView = false;
        }
    }
}