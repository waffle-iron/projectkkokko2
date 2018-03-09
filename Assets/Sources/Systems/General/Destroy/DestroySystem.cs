using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class DestroySystem : ICleanupSystem
{
    private readonly InputContext _input;
    private readonly CommandContext _command;
    private readonly IGroup<GameEntity> _game;
    private readonly IGroup<MetaEntity> _meta;

    public DestroySystem (Contexts contexts)
    {
        _input = contexts.input;
        _command = contexts.command;
        _game = contexts.game.GetGroup(GameMatcher.ToDestroy);
        _meta = contexts.meta.GetGroup(MetaMatcher.ToDestroy);
    }

    public void Cleanup ()
    {
        // Initialization code here
        foreach (var e in _input.GetEntities())
        {
            e.Destroy();
        }
        foreach (var e in _command.GetEntities())
        {
            e.Destroy();
        }

        foreach (var e in _game.GetEntities())
        {
            e.Destroy();
        }

        foreach (var e in _meta.GetEntities())
        {
            e.Destroy();
        }
    }
}