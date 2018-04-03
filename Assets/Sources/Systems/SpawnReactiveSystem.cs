using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class SpawnReactiveSystem : ReactiveSystem<GameEntity>
{
    private readonly MetaContext _meta;
    private readonly InputContext _input;

    public SpawnReactiveSystem (Contexts contexts) : base(contexts.game)
    {
        _meta = contexts.meta;
        _input = contexts.input;
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collector
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Timer, GameMatcher.Spawn));
    }

    protected override bool Filter (GameEntity entity)
    {
        // check for required components
        return entity.hasTimer &&
            entity.hasTimerState &&
            entity.timerState.isRunning &&
            entity.hasSpawn;
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            if (e.hasInterval == false)
            {
                AddNewRandomInterval(e);
            }

            if (e.timer.current >= e.interval.duration.GetInSeconds())
            {
                foreach (var id in e.spawn.entityID)
                {
                    _meta.entityService.instance.Get(id);
                }

                //reset
                var inputEty = _input.CreateEntity();
                inputEty.AddTargetEntityID(e.iD.value);
                inputEty.isTimerReset = true;
                AddNewRandomInterval(e);
            }
        }
    }

    void AddNewRandomInterval (GameEntity e)
    {
        var newDur = new DurationType(Random.Range(e.spawn.minInterval.GetInSeconds(), e.spawn.maxInterval.GetInSeconds()), UnitTime.Second);
        e.ReplaceInterval(newDur);
    }
}