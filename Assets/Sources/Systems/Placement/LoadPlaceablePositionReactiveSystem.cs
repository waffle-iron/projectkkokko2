using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class LoadPlaceablePositionReactiveSystem : ReactiveSystem<GameEntity>
{
    private const string savePlacementSuffix = "_placement";
    private InputContext _input;

    public LoadPlaceablePositionReactiveSystem (Contexts contexts) : base(contexts.game)
    {
        _input = contexts.input;
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collector
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Placeable, GameMatcher.SaveID));
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
            // do stuff to the matched entities
            var inputety = _input.CreateEntity();
            inputety.AddTargetEntityID(e.iD.value);
            inputety.AddLoad(e.saveID.value + savePlacementSuffix, false);

        }
    }
}