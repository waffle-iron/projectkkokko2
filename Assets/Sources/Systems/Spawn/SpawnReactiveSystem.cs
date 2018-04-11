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
            if (e.hasSpawnLimit && e.hasSpawnCounter && e.spawnCounter.current >= e.spawnLimit.count)
            {
                continue;
            }

            if (e.hasInterval == false)
            {
                AddNewRandomInterval(e);
            }

            if (e.timer.current >= e.interval.duration.GetInSeconds())
            {
                if (e.spawn.isRandomized)
                {
                    var id = e.spawn.entityID[Random.Range(0, e.spawn.entityID.Length)];
                    _meta.entityService.instance.Get(id);
                }
                else
                {
                    foreach (var id in e.spawn.entityID)
                    {
                        _meta.entityService.instance.Get(id);
                    }
                }

                if (e.hasSpawnLimit) { e.ReplaceSpawnCounter(e.hasSpawnCounter ? e.spawnCounter.current + 1 : 1); }

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