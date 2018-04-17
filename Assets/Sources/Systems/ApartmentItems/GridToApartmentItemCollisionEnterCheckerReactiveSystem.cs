using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class GridToApartmentItemCollisionEnterCheckerReactiveSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _game;

    public GridToApartmentItemCollisionEnterCheckerReactiveSystem (Contexts contexts) : base(contexts.game)
    {
        _game = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collector
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.OnCollision, GameMatcher.ApartmentItem, GameMatcher.Grid));
    }

    protected override bool Filter (GameEntity entity)
    {
        // check for required components
        return entity.hasOnCollision &&
            entity.onCollision.type == CollisionType.ENTER &&
            entity.hasApartmentItem &&
            entity.hasGrid;
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            var target = _game.GetEntityWithID(e.onCollision.otherID);

            if (target != null && target.hasApartmentItem)
            {
                if (e.apartmentItem.type == target.apartmentItem.type)
                {
                    if (target.hasValidGrid)
                    {
                        var existing = target.validGrid.gridIDs;
                        existing.Add(e.grid.id);
                        target.ReplaceValidGrid(existing);
                    }
                    else
                    {
                        target.ReplaceValidGrid(new List<string>(new string[] { e.grid.id }));
                    }
                }
            }
        }
    }
}