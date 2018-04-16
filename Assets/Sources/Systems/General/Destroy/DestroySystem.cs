using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class DestroySystem : ICleanupSystem
{
    private readonly InputContext _input;
    private readonly CommandContext _command;
    private readonly IGroup<GameEntity> _game;
    private readonly IGroup<GameEntity> _delaygame;
    private readonly IGroup<MetaEntity> _meta;

    private List<GameEntity> _gameBuffer = new List<GameEntity>();
    private List<MetaEntity> _metaBuffer = new List<MetaEntity>();
    private List<GameEntity> _gameDelayBuffer = new List<GameEntity>();

    public DestroySystem (Contexts contexts)
    {
        _input = contexts.input;
        _command = contexts.command;
        _game = contexts.game.GetGroup(GameMatcher.ToDestroy);
        _delaygame = contexts.game.GetGroup(GameMatcher.DelayDestroy);
        _meta = contexts.meta.GetGroup(MetaMatcher.ToDestroy);
    }

    public void Cleanup ()
    {
        // Initialization code here
        foreach (var e in _input.GetEntities())
        {
            if (e.hasDelayDestroy && e.delayDestroy.frames > 0)
            {
                e.ReplaceDelayDestroy(e.delayDestroy.frames - 1);
            }
            else
            {
                e.Destroy();
            }
        }
        foreach (var e in _command.GetEntities())
        {
            if (e.hasDelayDestroy && e.delayDestroy.frames > 0)
            {
                e.ReplaceDelayDestroy(e.delayDestroy.frames - 1);
            }
            else
            {
                e.Destroy();
            }
        }

        foreach (var e in _delaygame.GetEntities(_gameDelayBuffer))
        {
            if (e.hasDelayDestroy && e.delayDestroy.frames > 0)
            {
                e.ReplaceDelayDestroy(e.delayDestroy.frames - 1);
            }
            else
            {
                e.Destroy();
            }
        }

        foreach (var e in _game.GetEntities(_gameBuffer))
        {
            e.Destroy();
        }

        foreach (var e in _meta.GetEntities(_metaBuffer))
        {
            e.Destroy();
        }
    }
}