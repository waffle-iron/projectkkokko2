using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class LoadModEntitiesOnSceneLoadCompleteSystem : ReactiveSystem<GameEntity>
{
    private readonly IGroup<GameEntity> _savedList;
    private readonly InputContext _input;
    private readonly GameContext _game;
    private readonly MetaContext _meta;

    public LoadModEntitiesOnSceneLoadCompleteSystem (Contexts contexts) : base(contexts.game)
    {
        _savedList = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.SavedModifiedEntitiesConfigIDs, GameMatcher.Scenes));
        _input = contexts.input;
        _game = contexts.game;
        _meta = contexts.meta;
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collector
        //_game.isLoadSceneComplete && _game.isLoadedViewsComplete && _game.isLoadEntitiesComplete == false
        return context.CreateCollector(GameMatcher.AnyOf(GameMatcher.LoadSceneComplete,
                                                        GameMatcher.LoadedViewsComplete,
                                                        GameMatcher.LoadEntitiesComplete));
    }

    protected override bool Filter (GameEntity entity)
    {
        return _game.isLoadedViewsComplete &&
            _game.isLoadEntitiesComplete &&
            _game.isLoadSceneComplete;
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var list in _savedList)
        {
            if (list.scenes.names.Contains(_meta.loadSceneService.instance.ActiveScene))
            {
                foreach (var id in list.savedModifiedEntitiesConfigIDs.ids)
                {
                    _meta.entityService.instance.Get(id);
                }
            }
        }
    }
}