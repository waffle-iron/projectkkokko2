using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class InitializeCommandLoadViewsSystem : IInitializeSystem
{
    private readonly MetaContext _meta;
    private readonly GameContext _game;
    private readonly IGroup<CommandEntity> _loads;

    public InitializeCommandLoadViewsSystem (Contexts contexts)
    {
        _meta = contexts.meta;
        _game = contexts.game;
        _loads = contexts.command.GetGroup(CommandMatcher.LoadViews);
    }

    public void Initialize ()
    {
        foreach (var e in _loads.GetEntities())
        {
            // do stuff to the matched entities
            _game.CreateEntity().AddLoadViews(e.loadViews.paths, e.loadViews.includeSceneObjects);
            _meta.viewService.instance.Refresh(e.loadViews.includeSceneObjects, e.loadViews.paths);
        }
    }
}