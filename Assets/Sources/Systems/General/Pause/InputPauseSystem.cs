using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class InputPauseSystem : IExecuteSystem, IInitializeSystem
{
    private readonly CommandContext _command;
    private readonly GameContext _game;
    private readonly MetaContext _meta;

    private const string PAUSE_ENTITY = "pause";

    public InputPauseSystem (Contexts contexts)
    {
        _command = contexts.command;
        _game = contexts.game;
        _meta = contexts.meta;
    }

    public void Execute ()
    {
        if (_game.pause.state != _meta.pauseService.instance.state)
        {
            _command.CreateEntity().AddPause(_meta.pauseService.instance.state);
        }
    }

    public void Initialize ()
    {
        IEntity entity;
        if (_meta.entityService.instance.Get(PAUSE_ENTITY, out entity))
        {
            //do something when not found
        }
    }
}