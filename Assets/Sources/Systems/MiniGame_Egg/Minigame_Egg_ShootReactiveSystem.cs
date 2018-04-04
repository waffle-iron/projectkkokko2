using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;
using System.Linq;

public class Minigame_Egg_ShootReactiveSystem : ReactiveSystem<GameEntity>
{
    private readonly IGroup<GameEntity> _ball;

    public Minigame_Egg_ShootReactiveSystem (Contexts contexts) : base(contexts.game)
    {
        _ball = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Ball, GameMatcher.Tag, GameMatcher.Collidable, GameMatcher.CanThrow));
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
            entity.gameState.current.IsEqualTo(MiniGameEggState.SHOOT);
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            // do stuff to the matched entities
            //disable ball throwing
            foreach (var ball in _ball.AsEnumerable())
            {
                ball.ReplaceCanThrow(ball.canThrow.force, ball.canThrow.minDistance, false);
            }
        }
    }
}