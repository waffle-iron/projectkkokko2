using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class FoodCollisionReturnReactiveSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _game;

    public FoodCollisionReturnReactiveSystem (Contexts contexts) : base(contexts.game)
    {
        _game = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collector
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.OnCollision, GameMatcher.TouchPhase, GameMatcher.Food));
    }

    protected override bool Filter (GameEntity entity)
    {
        // check for required components
        return entity.hasOnCollision &&
            entity.onCollision.type == CollisionType.ENTER &&
            entity.hasTouchPhase &&
            entity.touchPhase.current == TouchPhase.Ended &&
            entity.hasFood &&
            entity.hasTargetEntityID;
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            var collisionEntity = _game.GetEntityWithID(e.onCollision.otherID);
            if (collisionEntity != null && collisionEntity.isReturn)
            {
                var food = _game.GetEntityWithID(e.targetEntityID.value);
                if (food != null) { food.isRemoveFromStorage = false; }

                e.isToDestroy = true;
            }
        }
    }
}