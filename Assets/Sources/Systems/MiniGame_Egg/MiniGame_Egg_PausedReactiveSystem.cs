using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class MiniGame_Egg_PausedReactiveSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _game;
    private readonly IGroup<GameEntity> _spawners;

    public MiniGame_Egg_PausedReactiveSystem (Contexts contexts) : base(contexts.game)
    {
        _game = contexts.game;
        _spawners = _game.GetGroup(GameMatcher.AllOf(GameMatcher.Spawn, GameMatcher.Timer, GameMatcher.TimerState));
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collector
        return context.CreateCollector(GameMatcher.GameState);
    }

    protected override bool Filter (GameEntity entity)
    {
        // check for required components
        return entity.hasGameState &&
            entity.gameState.current.IsEqualTo(MiniGameEggState.PAUSE_GAME);
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            // do stuff to the matched entities
            foreach (var spawn in _spawners.GetEntities())
            {
                spawn.ReplaceTimerState(false);
            }
        }
    }
}