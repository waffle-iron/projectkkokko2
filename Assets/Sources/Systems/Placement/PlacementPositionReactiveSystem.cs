using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class PlacementPositionReactiveSystem : ReactiveSystem<GameEntity>
{
    public PlacementPositionReactiveSystem (Contexts contexts) : base(contexts.game)
    {
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collector
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.PlaceablePosition));
    }

    protected override bool Filter (GameEntity entity)
    {
        // check for required components
        return entity.hasPosition && entity.hasPlaceablePosition;
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            // do stuff to the matched entities
            if (e.position.current != e.placeablePosition.current)
            {
                e.ReplacePosition(e.placeablePosition.current);
            }
        }
    }
}