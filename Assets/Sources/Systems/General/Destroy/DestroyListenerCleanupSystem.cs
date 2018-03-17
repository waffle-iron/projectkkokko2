using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class DestroyListenerCleanupSystem : ReactiveSystem<GameEntity>
{
    private readonly IGroup<GameEntity> _destroys;
    public DestroyListenerCleanupSystem (Contexts contexts) : base(contexts.game)
    {
        _destroys = contexts.game.GetGroup(GameMatcher.GameToDestroyListener);
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collector
        return context.CreateCollector(GameMatcher.LoadScene.Removed());
    }

    protected override bool Filter (GameEntity entity)
    {
        // check for required components
        return true;
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            foreach (var dty in _destroys.GetEntities())
            {
                dty.gameToDestroyListener.value.RemoveAll(view => view == null);
            }
        }
    }
}