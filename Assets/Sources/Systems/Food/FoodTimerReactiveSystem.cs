using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class FoodTimerReactiveSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _game;
    private readonly InputContext _input;

    public FoodTimerReactiveSystem (Contexts contexts) : base(contexts.game)
    {
        _game = contexts.game;
        _input = contexts.input;
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collector
        return context.CreateCollector(GameMatcher.Consuming.AddedOrRemoved());
    }

    protected override bool Filter (GameEntity entity)
    {
        // check for required components
        return entity.hasFood && entity.hasTimer;
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            var inputEty = _input.CreateEntity();
            inputEty.AddTargetEntityID(e.iD.value);
            inputEty.isTimerReset = true;

            if (e.hasConsuming) { inputEty.AddTimerState(true); }
            else { inputEty.AddTimerState(false); }
        }
    }
}