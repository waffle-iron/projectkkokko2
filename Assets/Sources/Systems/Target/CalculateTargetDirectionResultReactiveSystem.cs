using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class CalculateTargetDirectionResultReactiveSystem : ReactiveSystem<GameEntity>
{
    public CalculateTargetDirectionResultReactiveSystem (Contexts contexts) : base(contexts.game)
    {
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collector
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Velocity, GameMatcher.TargetDirectionChecker));
    }

    protected override bool Filter (GameEntity entity)
    {
        // check for required components
        return entity.hasTargetDirectionChecker &&
            entity.hasTargetPosition &&
            entity.hasPosition &&
            entity.hasVelocity;
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            var myDirection = e.velocity.current.normalized;
            var idealDirection = (e.targetPosition.value - e.position.current).normalized;

            var angle = Vector2.Angle(myDirection, idealDirection);

            e.ReplaceTargetDirectionCheckResult(angle <= e.targetDirectionChecker.angle, idealDirection);
        }
    }
}