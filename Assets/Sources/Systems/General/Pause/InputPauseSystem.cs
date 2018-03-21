using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class InputPauseSystem : IExecuteSystem
{
    private readonly CommandContext _command;
    private readonly GameContext _game;
    private readonly MetaContext _meta;

    public InputPauseSystem (Contexts contexts)
    {
        _command = contexts.command;
        _game = contexts.game;
        _meta = contexts.meta;
    }

    public void Execute ()
    {
        if (_game.pauseEntity != null && _game.pause.state != _meta.pauseService.instance.state)
        {
            _command.CreateEntity().AddPause(_meta.pauseService.instance.state);
        }
    }
}