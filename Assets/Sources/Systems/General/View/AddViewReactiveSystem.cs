using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class AddViewReactiveSystem : ReactiveSystem<GameEntity>
{
    private readonly MetaContext _meta;
    private readonly GameContext _game;

    public AddViewReactiveSystem (Contexts contexts) : base(contexts.game)
    {
        _meta = contexts.meta;
        _game = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collector
        return context.CreateCollector(GameMatcher.View.Added());
    }

    protected override bool Filter (GameEntity entity)
    {
        // check for required components
        return entity.hasView && entity.isAddedView == false;
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            // do stuff to the matched entities
            _meta.viewService.instance.Load(_game, e, e.view.name);
            e.isAddedView = true;
        }
    }
}