using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;
using UniRx;

public class CommandLoadViewsReactiveSystem : ReactiveSystem<CommandEntity>
{
    private readonly MetaContext _meta;
    private readonly GameContext _game;

    public CommandLoadViewsReactiveSystem (Contexts contexts) : base(contexts.command)
    {
        _meta = contexts.meta;
        _game = contexts.game;
    }

    protected override ICollector<CommandEntity> GetTrigger (IContext<CommandEntity> context)
    {
        //return collector
        return context.CreateCollector(CommandMatcher.LoadViews);
    }

    protected override bool Filter (CommandEntity entity)
    {
        // check for required components
        return entity.hasLoadViews;
    }

    protected override void Execute (List<CommandEntity> entities)
    {
        foreach (var e in entities)
        {
            // do stuff to the matched entities
            _meta.viewService.instance.Populate(e.loadViews.includeSceneObjects, e.loadViews.paths)
                .Where(result => result == true)
                .Subscribe(_ => _game.isLoadedViewsComplete = true);
        }
    }
}