using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class InputTouchTargetMovePlayerReactiveSystem : IExecuteSystem
{
    private readonly MetaContext _meta;
    private readonly CommandContext _cmd;
    private readonly GameContext _game;

    private readonly IGroup<GameEntity> _players;

    public InputTouchTargetMovePlayerReactiveSystem (Contexts contexts)
    {
        _meta = contexts.meta;
        _cmd = contexts.command;
        _game = contexts.game;
        _players = _game.GetGroup(GameMatcher.Player);
    }

    public void Execute ()
    {
        if (_meta.touchService.instance.touch != null)
        {
            //do filter checks then add to command touch service
            if (_game.gameState.state == GameState.PLAYING)
            {
                foreach (var player in _players.GetEntities())
                {
                    var cmdEty = _cmd.CreateEntity();
                    cmdEty.AddTargetEntityID(player.iD.value);
                    cmdEty.AddTargetMove(_meta.touchService.instance.touch[0].WorldPosition);
                }
            }
        }
    }
}