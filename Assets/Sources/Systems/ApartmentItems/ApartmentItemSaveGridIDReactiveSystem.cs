using System.Collections.Generic;
using System.Linq;
using System.Collections;
using UnityEngine;
using Entitas;

public class ApartmentItemSaveGridIDReactiveSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _game;

    public ApartmentItemSaveGridIDReactiveSystem (Contexts contexts) : base(contexts.game)
    {
        _game = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collector
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.TouchData, GameMatcher.ApartmentItem, GameMatcher.ValidGrid));
    }

    protected override bool Filter (GameEntity entity)
    {
        // check for required components
        return entity.hasTouchData &&
            entity.touchData.current.Phase == TouchPhase.Ended || entity.touchData.current.Phase == TouchPhase.Canceled &&
            entity.hasApartmentItem &&
            entity.hasPosition &&
            entity.hasValidGrid;
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            //remove other grid data and contain only nearest
            if (e.validGrid.gridIDs.Count > 1)
            {
                var nearest = e.validGrid.gridIDs.Select(id => _game.GetEntityWithGrid(id))
                                                .OrderBy(grid => Vector3.Distance(e.position.current, grid.position.current))
                                                .FirstOrDefault();
                e.ReplaceAssignedToGrid(nearest.grid.id);
            }
            else if (e.validGrid.gridIDs.Count == 1)
            {
                e.ReplaceAssignedToGrid(e.validGrid.gridIDs[0]);
            }
            else
            {
                e.ReplaceAssignedToGrid("");
            }
        }
    }