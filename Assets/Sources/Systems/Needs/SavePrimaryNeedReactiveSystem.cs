using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class SavePrimaryNeedReactiveSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _game;
    private readonly InputContext _input;

    public SavePrimaryNeedReactiveSystem (Contexts contexts) : base(contexts.game)
    {
        _game = contexts.game;
        _input = contexts.input;
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collector
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Current, GameMatcher.Need));
    }

    protected override bool Filter (GameEntity entity)
    {
        return entity.hasCurrent &&
            entity.hasNeed &&
            (entity.need.type == NeedType.HEALTH || entity.need.type == NeedType.MOOD) &&
            entity.hasSaveID;
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            var saveEntity = _game.CreateEntity();
            saveEntity.AddCurrent(e.current.amount);
            saveEntity.AddSaveID(e.saveID.value);
            saveEntity.AddDelayDestroy(1);

            var inputEty = _input.CreateEntity();
            inputEty.AddTargetEntityID(saveEntity.iD.value);
            inputEty.isSave = true;
        }
    }
}