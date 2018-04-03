using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class TimerUpdateSystem : IExecuteSystem
{
    private IGroup<GameEntity> _timers;
    private List<GameEntity> _buffer = new List<GameEntity>();

    private readonly MetaContext _meta;
    private readonly GameContext _game;

    public TimerUpdateSystem (Contexts contexts)
    {
        _timers = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Timer, GameMatcher.TimerState));
        _meta = contexts.meta;
        _game = contexts.game;
    }

    public void Execute ()
    {
        foreach (var e in _timers.GetEntities(_buffer))
        {
            if (e.timerState.isRunning && _game?.pause?.state == false && 
                _game.gameState.current.type == typeof(MainGameState) && 
                _game.gameState.current.state == (int)MainGameState.PLAYING)
            {
                e.ReplaceTimer(e.timer.current + _meta.timeService.instance.delta);
            }
        }
    }
}