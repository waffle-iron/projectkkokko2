using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class CollisionReturnReactiveSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _game;

    public CollisionReturnReactiveSystem (Contexts contexts) : base(contexts.game)
    {
        _game = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collector
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.OnCollision, GameMatcher.TouchData, GameMatcher.Returnable));
    }

    protected override bool Filter (GameEntity entity)
    {
        // check for required components
        return entity.hasOnCollision &&
            (entity.onCollision.type == CollisionType.ENTER || entity.onCollision.type == CollisionType.STAY) &&
            entity.hasTouchData &&
            entity.touchData.current.Phase == TouchPhase.Ended &&
            entity.isReturnable;
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            var collisionEntity = _game.GetEntityWithID(e.onCollision.otherID);
            if (collisionEntity != null && collisionEntity.isReturn)
            {
                //food conditions
                if (e.hasFood && e.hasTargetEntityID)
                {
                    var food = _game.GetEntityWithID(e.targetEntityID.value);
                    if (food != null) { food.isRemoveFromStorage = false; }
                }

                e.isToDestroy = true;
            }
        }
    }
}