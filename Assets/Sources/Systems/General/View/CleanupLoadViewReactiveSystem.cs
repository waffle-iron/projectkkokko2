using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class CleanupLoadViewReactiveSystem : ICleanupSystem
{
    private IGroup<GameEntity> _loads;

    public CleanupLoadViewReactiveSystem (Contexts contexts)
    {
        _loads = contexts.game.GetGroup(GameMatcher.LoadViews);
    }

    public void Cleanup ()
    {
        // Initialization code here
        foreach (var e in _loads.GetEntities())
        {
            e.isToDestroy = true;
        }
    }
}