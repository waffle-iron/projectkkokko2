using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class FoodConsumingOnPlayerCollisionReactiveSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _game;

    public FoodConsumingOnPlayerCollisionReactiveSystem (Contexts contexts) : base(contexts.game)
    {
        _game = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collector
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Food, GameMatcher.OnCollision));
    }

    protected override bool Filter (GameEntity entity)
    {
        // check for required components
        return entity.hasFood && entity.hasOnCollision;
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            var player = _game.GetEntityWithID(e.onCollision.otherID);

            if (player != null && player.isPlayer)
            {
                if (player.hasConsuming == false && player.onCollision.type == CollisionType.ENTER)
                {
                    player.AddConsuming(player.iD.value, e.iD.value);
                    e.AddConsuming(player.iD.value, e.iD.value);
                }
                else if (player.hasConsuming && player.onCollision.type == CollisionType.EXIT)
                {
                    player.RemoveConsuming();
                    e.RemoveConsuming();
                }
            }
        }
    }
}