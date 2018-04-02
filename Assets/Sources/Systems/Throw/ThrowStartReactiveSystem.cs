using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class ThrowStartReactiveSystem : ReactiveSystem<GameEntity>
{
    private readonly MetaContext _meta;

    public ThrowStartReactiveSystem (Contexts contexts) : base(contexts.game)
    {
        _meta = contexts.meta;
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collector
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.TouchData));
    }

    protected override bool Filter (GameEntity entity)
    {
        // check for required components
        return entity.hasTouchData &&
            entity.touchData.current.Phase == TouchPhase.Ended &&
            entity.hasCanThrow && 
            entity.hasOrigin;
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            //get new position
            //filter min distance
            //if it passes, calculate for velocity and add
            var endPos = e.touchData.current.WorldPosition;
            _meta.debugService.instance.Log(Vector2.Distance(endPos, e.origin.current));
            if (Vector2.Distance(endPos, e.origin.current) > e.canThrow.minDistance)
            {
                var direction = endPos - e.origin.current;
                e.ReplaceVelocity(direction.normalized * e.canThrow.force);
            }
        }
    }
}