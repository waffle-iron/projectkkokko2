using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class ApartmentPlacementReleaseReactiveSystem : ReactiveSystem<GameEntity>
{
    public ApartmentPlacementReleaseReactiveSystem (Contexts contexts) : base(contexts.game)
    {
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collector
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.TouchData, GameMatcher.Placeable));
    }

    protected override bool Filter (GameEntity entity)
    {
        // check for required components
        return entity.hasTouchData &&
            (entity.touchData.current.Phase == TouchPhase.Ended || entity.touchData.current.Phase == TouchPhase.Canceled) &&
            entity.isPlaceable &&
            entity.hasPreviousPosition &&
            entity.hasPosition &&
            entity.hasValidPlacement;
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            // do stuff to the matched entities
            e.ReplacePlaceablePosition(e.validPlacement.state ? e.position.current : e.previousPosition.current);
        }
    }
}