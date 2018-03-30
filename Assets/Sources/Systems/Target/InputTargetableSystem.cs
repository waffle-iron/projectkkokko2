using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine;
using Entitas;

public class InputTargetableSystem : IExecuteSystem
{
    private IGroup<GameEntity> _targets;
    private InputContext _input;
    private GameContext _game;
    private List<GameEntity> _buffer;
    private IGroup<GameEntity> _player;

    public InputTargetableSystem (Contexts contexts)
    {
        _input = contexts.input;
        _game = contexts.game;
        _targets = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Targetable, GameMatcher.Position));
        _player = contexts.game.GetGroup(GameMatcher.Player);
        _buffer = new List<GameEntity>();
    }

    public void Execute ()
    {
        if (_targets.GetEntities(_buffer).Count > 0 && _game.gameState.state == GameState.PLAYING)
        {
            foreach (var player in _player.GetEntities())
            {
                var nearestTarget = GetNearest(_targets.GetEntities(), player);
                var inputEty = _input.CreateEntity();
                inputEty.AddTargetEntityID(player.iD.value);
                inputEty.AddTargetMove(nearestTarget.position.current, player.followTarget.stopDistance);
            }
        }
    }

    private GameEntity GetNearest (GameEntity[] positions, GameEntity refPoint)
    {
        if (positions == null || positions.Length == 0)
        {
            return null;
        }
        else if (positions.Length == 1) { return positions[0]; }

        return positions.Aggregate((nearest, curr) =>
        {
            if (Mathf.Abs(Vector3.Distance(refPoint.position.current, curr.position.current)) <
                Mathf.Abs(Vector3.Distance(refPoint.position.current, nearest.position.current)))
            {
                return curr;
            }
            else { return nearest; }
        });
    }
}