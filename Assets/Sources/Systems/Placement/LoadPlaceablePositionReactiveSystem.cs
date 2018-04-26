using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class LoadPlaceablePositionReactiveSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _game;
    private readonly InputContext _input;
    private readonly MetaContext _meta;

    public LoadPlaceablePositionReactiveSystem (Contexts contexts) : base(contexts.game)
    {
        _input = contexts.input;
        _game = contexts.game;
        _meta = contexts.meta;
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collector
        return context.CreateCollector(GameMatcher.AnyOf(GameMatcher.LoadSceneComplete, GameMatcher.LoadedViewsComplete));
    }

    protected override bool Filter (GameEntity entity)
    {
        // check for required components
        return _game.isLoadedViewsComplete &&
            _game.isLoadSceneComplete &&
            _game.hasApartmentItemsInstanceData &&
            _game.apartmentItemsInstanceDataEntity.hasScenes &&
            _game.apartmentItemsInstanceDataEntity.scenes.names.Contains(_meta.loadSceneService.instance.ActiveScene);
    }

    protected override void Execute (List<GameEntity> entities)
    {
        if (_game.hasApartmentItemsInstanceData)
        {
            var savedData = _game.apartmentItemsInstanceData.data;

            foreach (var save in savedData)
            {
                foreach (var pos in save.Value)
                {
                    IEntity entity;
                    _meta.entityService.instance.Get(save.Key, out entity);

                    if (entity != null)
                    {
                        var gameety = (GameEntity)entity;
                        gameety.ReplacePlaceablePosition(pos.Value);
                        gameety.AddApartmentInstanceSaveID(pos.Key);
                        gameety.ReplacePreviousPosition(pos.Value);
                        gameety.ReplaceValidPlacement(true);

                        //hacky shit
                        if (_meta.loadSceneService.instance.ActiveScene == "ApartmentCustomize_Scene") { gameety.isPlaceable = true; }
                        else { gameety.isPlaceable = false; }
                    }
                }
            }
        }
    }
}