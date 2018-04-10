using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class PauseEnergyOnSleepReactiveSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _game;
    private readonly InputContext _input;

    public PauseEnergyOnSleepReactiveSystem (Contexts contexts) : base(contexts.game)
    {
        _game = contexts.game;
        _input = contexts.input;
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collector
        return context.CreateCollector(GameMatcher.Sleep.AddedOrRemoved());
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
            var energyNeed = _game.GetEntityWithNeed(NeedType.ENERGY);

            if (energyNeed != null && energyNeed.hasTimer)
            {
                var inputEty = _input.CreateEntity();
                inputEty.AddTargetEntityID(energyNeed.iD.value);

                if (e.isSleep) { inputEty.AddTimerState(false); }
                else { inputEty.AddTimerState(true); }
            }
        }
    }
}