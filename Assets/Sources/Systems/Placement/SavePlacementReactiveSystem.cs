using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class SavePlacementReactiveSystem : ReactiveSystem<GameEntity>
{
    private readonly InputContext _input;
    private readonly GameContext _game;
    private const string savePlacementSuffix = "_placement";

    public SavePlacementReactiveSystem (Contexts contexts) : base(contexts.game)
    {
        _input = contexts.input;
        _game = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collector
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.TouchData, GameMatcher.Placeable));
    }

    protected override bool Filter (GameEntity entity)
    {
        // check for required components
        return entity.hasTouchData &&
            entity.touchData.current.Phase == TouchPhase.Ended &&
            entity.hasPlaceablePosition;
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            // do stuff to the matched entities
            var saveety = _game.CreateEntity();
            saveety.AddPlaceablePosition(e.placeablePosition.current);
            saveety.AddDelayDestroy(1);
            saveety.AddSaveID(e.saveID.value);

            var inputety = _input.CreateEntity();
            inputety.AddTargetEntityID(saveety.iD.value);
            inputety.isSave = true;
            inputety.AddSaveVariant(savePlacementSuffix);
        }
    }
}