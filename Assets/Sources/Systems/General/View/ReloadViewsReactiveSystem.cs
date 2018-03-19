using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class ReloadViewsReactiveSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _game;
    private readonly MetaContext _meta;
    private readonly IGroup<GameEntity> _views;

    public ReloadViewsReactiveSystem (Contexts contexts) : base(contexts.game)
    {
        _game = contexts.game;
        _meta = contexts.meta;
        _views = _game.GetGroup(GameMatcher.AllOf(GameMatcher.View).NoneOf(GameMatcher.ToDestroy));
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collector
        return context.CreateCollector(GameMatcher.LoadedViewsComplete);
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
            foreach (var viewEntity in _views.GetEntities())
            {
                if (viewEntity.isAddedView || viewEntity.view.reloadOnSceneChange == false) { continue; }
                else
                {
                    _meta.viewService.instance.Instantiate(_game, viewEntity, viewEntity.view.name);
                    viewEntity.isAddedView = true;
                }
            }
        }
    }
}