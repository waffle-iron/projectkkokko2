using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System.Linq;
using Entitas;

public class Minigame_Egg_StartGameReactiveSystem : ReactiveSystem<GameEntity>
{
    private readonly IGroup<GameEntity> _ball;
    private const string BALL_TAG = "Ball";

    public Minigame_Egg_StartGameReactiveSystem (Contexts contexts) : base(contexts.game)
    {
        _ball = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Tag, GameMatcher.Collidable, GameMatcher.CanThrow));
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
            foreach (var ball in _ball.AsEnumerable().Where(ball => ball.tag.current.Equals(BALL_TAG)))
            {
                ball.ReplaceCanThrow(ball.canThrow.force, ball.canThrow.minDistance, true);
            }
        }
    }
}