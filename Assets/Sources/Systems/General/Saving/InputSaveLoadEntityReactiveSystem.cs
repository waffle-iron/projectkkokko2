using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class InputSaveLoadEntityReactiveSystem : ReactiveSystem<InputEntity>
{
    private readonly GameContext _game;
    private readonly CommandContext _command;

    public InputSaveLoadEntityReactiveSystem (Contexts contexts) : base(contexts.input)
    {
        _game = contexts.game;
        _command = contexts.command;
    }

    protected override ICollector<InputEntity> GetTrigger (IContext<InputEntity> context)
    {
        //return collector
        return context.CreateCollector(InputMatcher.AllOf(InputMatcher.TargetEntityID).AnyOf(InputMatcher.Save, InputMatcher.Load));
    }

    protected override bool Filter (InputEntity entity)
    {
        // check for required components
        return entity.hasTargetEntityID;
    }

    protected override void Execute (List<InputEntity> entities)
    {
        foreach (var e in entities)
        {
            var target = _game.GetEntityWithID(e.targetEntityID.value);
            if (target != null)
            {
                var cmdEntity = _command.CreateEntity();
                cmdEntity.AddTargetEntityID(e.targetEntityID.value);

                if (e.isSave && target.hasSaveID)
                {
                    cmdEntity.isSave = true;
                }
                else
                {
                    cmdEntity.AddLoad(e.load.id, e.load.createNew);
                }
            }
        }
    }
}