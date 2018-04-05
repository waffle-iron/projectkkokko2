using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System.Linq;
using Entitas;

public class Minigame_Egg_StartGameReactiveSystem : ReactiveSystem<GameEntity>
{
    private readonly IGroup<GameEntity> _ball;
    private readonly IGroup<GameEntity> _spawners;

    private readonly InputContext _input;

    private readonly int SPAWN_COIN = 1;

    public Minigame_Egg_StartGameReactiveSystem (Contexts contexts) : base(contexts.game)
    {
        _input = contexts.input;
        _ball = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Tag, GameMatcher.Ball, GameMatcher.Collidable, GameMatcher.CanThrow));
        _spawners = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Spawn, GameMatcher.Timer, GameMatcher.TimerState));
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
            entity.gameState.current.IsEqualTo(MiniGameEggState.START_GAME);
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            // do stuff to the matched entities
            //enabled ball throwing
            foreach (var ball in _ball.GetEntities())
            {
                ball.ReplaceCanThrow(ball.canThrow.force, ball.canThrow.minDistance, true);
            }

            foreach (var spawn in _spawners.GetEntities())
            {
                var inputEty = _input.CreateEntity();
                //if scoin spawner, check to activate/deactivate
                if (spawn.hasCoin && spawn.hasScore)
                {
                    inputEty.AddTargetEntityID(spawn.iD.value);
                    if (spawn.score.value > 0 && spawn.score.value % SPAWN_COIN == 0)
                    {
                        inputEty.AddTimerState(true);
                    }
                    else
                    {
                        inputEty.AddTimerState(false);
                    }
                }
                else
                {
                    inputEty.ReplaceTimerState(true);
                }


            }
        }
    }
}