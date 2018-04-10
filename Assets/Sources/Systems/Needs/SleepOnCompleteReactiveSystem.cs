using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class SleepOnCompleteReactiveSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _game;
    private readonly InputContext _input;
    private readonly MetaContext _meta;

    public SleepOnCompleteReactiveSystem (Contexts contexts) : base(contexts.game)
    {
        _game = contexts.game;
        _input = contexts.input;
        _meta = contexts.meta;
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collectorr
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Sleep, GameMatcher.Timer));
    }

    protected override bool Filter (GameEntity entity)
    {
        // check for required components
        return entity.isSleep &&
            entity.hasTrigger &&
            entity.hasTimer &&
            entity.trigger.state == false;
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            if (e.timer.current >= e.trigger.duration.GetInSeconds())
            {
                e.ReplaceTrigger(e.trigger.duration, true);

                var service = _meta.entityService.instance;
                if (e.hasEntity)
                {
                    foreach (var entity in e.entity.entities)
                    {
                        service.Get(entity);
                    }
                }
                else
                {
                    _meta.debugService.instance.LogError("No entity to create");
                }
            }
        }
    }
}