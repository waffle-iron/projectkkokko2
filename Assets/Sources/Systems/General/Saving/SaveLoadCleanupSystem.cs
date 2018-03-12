using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class SaveLoadCleanupSystem : ICleanupSystem
{
    private readonly IGroup<GameEntity> _game;
    private List<GameEntity> _buffer = new List<GameEntity>();

    public SaveLoadCleanupSystem (Contexts contexts)
    {
        _game = contexts.game.GetGroup(GameMatcher.AnyOf(GameMatcher.Saving, GameMatcher.Loading));
    }

    public void Cleanup ()
    {
        // Initialization code here
        foreach (var e in _game.GetEntities(_buffer))
        {
            if (e.isSaving) { e.isSaving = false; }
            if (e.isLoading) { e.isLoading = false; }
        }
    }
}