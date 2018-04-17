using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class GridToApartmentItemCollisionExitCheckerReactiveSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _game;

    public GridToApartmentItemCollisionExitCheckerReactiveSystem (Contexts contexts) : base(contexts.game)
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
            entity.onCollision.type == CollisionType.EXIT &&
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

                if (target.hasValidGrid && target.validGrid.gridIDs.Contains(e.grid.id))
                {
                    var existing = target.validGrid.gridIDs;
                    existing.Remove(e.grid.id);
                    target.ReplaceValidGrid(existing);
                }

                if (target.hasValidGrid && target.validGrid.gridIDs.Count == 0)
                {
                    target.RemoveValidGrid();
                }

            }
        }
    }
}