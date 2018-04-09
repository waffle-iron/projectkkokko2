using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class InputTouchTargetMovePlayerReactiveSystem : IExecuteSystem
{
    private readonly MetaContext _meta;
    private readonly InputContext _input;
    private readonly GameContext _game;

    private readonly IGroup<GameEntity> _players;

    public InputTouchTargetMovePlayerReactiveSystem (Contexts contexts)
    {
        _meta = contexts.meta;
        _input = contexts.input;
        _game = contexts.game;
        _players = _game.GetGroup(GameMatcher.AllOf(GameMatcher.Player, GameMatcher.FollowTarget));
    }

    public void Execute ()
    {
        if (_meta.touchService.instance.touch != null)
        {
            //do filter checks then add to command touch service
            if (_game.hasGameState && _game.gameState.current.IsEqualTo(MainGameState.PLAYING))
            {
                foreach (var player in _players.GetEntities())
                {
                    var inputEty = _input.CreateEntity();
                    inputEty.AddTargetEntityID(player.iD.value);
                    inputEty.AddTargetMove(_meta.touchService.instance.touch[0].WorldPosition, player.followTarget.stopDistance);
                }
            }
        }
    }
}