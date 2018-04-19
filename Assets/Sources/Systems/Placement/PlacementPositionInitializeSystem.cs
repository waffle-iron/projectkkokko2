using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class PlacementPositionInitializeSystem : IInitializeSystem
{
    private IGroup<GameEntity> _placeables;

    public PlacementPositionInitializeSystem (Contexts contexts)
    {
        _placeables = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Placeable, GameMatcher.Moveable, GameMatcher.PlaceablePosition));
    }

    public void Initialize ()
    {
        // Initialization code here
        foreach (var placeable in _placeables)
        {
            placeable.ReplacePosition(placeable.placeablePosition.current);
        }
    }
}