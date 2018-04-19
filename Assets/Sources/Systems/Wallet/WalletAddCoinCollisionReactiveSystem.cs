using System.Linq;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class WalletAddCoinCollisionReactiveSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _game;
    private readonly InputContext _input;

    public WalletAddCoinCollisionReactiveSystem (Contexts contexts) : base(contexts.game)
    {
        _game = contexts.game;
        _input = contexts.input;
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collector
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.OnCollision));
    }

    protected override bool Filter (GameEntity entity)
    {
        // check for required components
        return entity.hasOnCollision &&
            entity.onCollision.data[0].Type == CollisionType.ENTER &&
            entity.hasCoin &&
            entity.hasTargetTag;
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            var target = _game.GetEntityWithID(e.onCollision.data[0].ID);

            if (target != null && target.hasTag && e.targetTag.current.Any(tag => tag == target.tag.current))
            {
                var inputEty = _input.CreateEntity();
                inputEty.AddCoin(e.coin.value, e.coin.operation);
            }

            e.isToDestroy = true;
        }
    }
}