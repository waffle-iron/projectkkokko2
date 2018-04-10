using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class PoopModifyHygieneReactiveSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _game;
    private readonly InputContext _input;

    public PoopModifyHygieneReactiveSystem (Contexts contexts) : base(contexts.game)
    {
        _game = contexts.game;
        _input = contexts.input;
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collector
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Interval, GameMatcher.Timer, GameMatcher.Poop));
    }

    protected override bool Filter (GameEntity entity)
    {
        // check for required components
        return entity.hasPoop &&
            entity.hasInterval &&
            entity.hasTimer &&
            entity.timer.current >= entity.interval.duration.GetInSeconds();
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            //get target need
            var target = _game.GetEntityWithNeed(NeedType.HYGIENE);

            if (target != null && target.hasTimer)
            {
                //add time to timer
                target.ReplaceTimer(target.timer.current + e.poop.add.GetInSeconds());

                //reset timer
                var inputEntity = _input.CreateEntity();
                inputEntity.AddTargetEntityID(e.iD.value);
                inputEntity.isTimerReset = true;
            }
        }
    }
}