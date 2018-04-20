using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System.Linq;
using Entitas;

public class ApartmentPlacementCollisionCheckerReactiveSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _game;

    public ApartmentPlacementCollisionCheckerReactiveSystem (Contexts contexts) : base(contexts.game)
    {
        _game = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collector
        return context.CreateCollector(GameMatcher.OnCollision);
    }

    protected override bool Filter (GameEntity entity)
    {
        // check for required components
        return entity.hasApartmentItem && entity.isPlaceable;
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            var validCollisions = e.onCollision.data
                .Where(data => data.Type == CollisionType.ENTER || data.Type == CollisionType.STAY);

            if (validCollisions.Count() > 0)
            {
                var result = validCollisions.Select(data => _game.GetEntityWithID(data.ID))
                .Any(ety => ety.isSpace == false);

                e.ReplaceValidPlacement(!result);
            }
            else
            {
                e.ReplaceValidPlacement(false);
            }

        }
    }
}