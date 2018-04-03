using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System.Linq;
using Entitas;

public class ScoreCollideReactiveSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _game;
    private readonly InputContext _input;

    public ScoreCollideReactiveSystem (Contexts contexts) : base(contexts.game)
    {
        _game = contexts.game;
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
            entity.onCollision.type == CollisionType.ENTER &&
            entity.hasChangeScore &&
            entity.hasTargetTag;
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            var target = _game.GetEntityWithID(e.onCollision.otherID);

            if (target != null && target.hasTag && string.IsNullOrEmpty(e.targetTag.current.FirstOrDefault(tag => tag.Equals(target.tag))) == false)
            {
                var inputEty = _input.CreateEntity();
                inputEty.AddChangeScore(e.changeScore.value, e.changeScore.operation);
            }
        }
    }
}