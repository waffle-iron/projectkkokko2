using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class ApartmentPlacementInitPosReactiveSystem : ReactiveSystem<GameEntity>
{
    public ApartmentPlacementInitPosReactiveSystem (Contexts contexts) : base(contexts.game)
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
            entity.touchData.current.Phase == TouchPhase.Began &&
            entity.isPlaceable &&
            entity.hasMoveable && entity.hasPosition;
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            // do stuff to the matched entities
            if (e.hasPlaceablePosition)
            {
                e.ReplacePreviousPosition(e.placeablePosition.current);
            }
            else
            {
                e.ReplacePreviousPosition(e.position.current);
            }
        }
    }
}