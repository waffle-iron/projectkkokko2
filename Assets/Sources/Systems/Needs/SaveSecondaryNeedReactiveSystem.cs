using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;
using System;

public class SaveSecondaryNeedReactiveSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _game;
    private readonly InputContext _input;

    public SaveSecondaryNeedReactiveSystem (Contexts contexts) : base(contexts.game)
    {
        _game = contexts.game;
        _input = contexts.input;
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collector
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Need).AnyOf(GameMatcher.NeedForceSave, GameMatcher.Trigger));
    }

    protected override bool Filter (GameEntity entity)
    {
        // check for required components
        return entity.hasTrigger &&
            entity.hasNeed &&
            (entity.need.type != NeedType.HEALTH && entity.need.type != NeedType.MOOD) &&
            entity.hasTimer &&
            entity.hasSaveID;
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            var saveEntity = _game.CreateEntity();
            if (e.isNeedForceSave) { saveEntity.AddTimer(0f); }
            else { saveEntity.AddTimer(e.timer.current); }
            
            saveEntity.AddSuspendedTime(DateTime.Now);
            saveEntity.AddSaveID(e.saveID.value);
            saveEntity.AddTrigger(e.trigger.duration, e.trigger.state);
            saveEntity.AddDelayDestroy(1);

            var inputEty = _input.CreateEntity();
            inputEty.AddTargetEntityID(saveEntity.iD.value);
            inputEty.isSave = true;

            e.isNeedForceSave = false;
        }
    }
}