using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class ObstacleCollisionDestroyReactiveSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _game;

    public ObstacleCollisionDestroyReactiveSystem (Contexts contexts) : base(contexts.game)
    {
        _game = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collector
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.OnCollision, GameMatcher.Obstacle));
    }

    protected override bool Filter (GameEntity entity)
    {
        // check for required components
        return entity.hasOnCollision && entity.isObstacle;
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            var target = _game.GetEntityWithID(e.onCollision.otherID);
            if (target.isCanDestroyOther)
            {
                e.isToDestroy = true;
            }
        }
    }
}