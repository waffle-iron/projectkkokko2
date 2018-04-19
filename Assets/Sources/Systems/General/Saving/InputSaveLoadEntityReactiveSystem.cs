using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class InputSaveLoadEntityReactiveSystem : ReactiveSystem<InputEntity>
{
    private readonly GameContext _game;
    private readonly CommandContext _command;
    private readonly MetaContext _meta;

    public InputSaveLoadEntityReactiveSystem (Contexts contexts) : base(contexts.input)
    {
        _game = contexts.game;
        _command = contexts.command;
        _meta = contexts.meta;
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
                    if (e.hasSaveVariant) { cmdEntity.AddSaveVariant(e.saveVariant.suffix); }
                }
                else if (e.hasLoad)
                {
                    cmdEntity.AddLoad(e.load.id, e.load.createNew);
                }
                else
                {
                    _meta.debugService.instance.LogError("no save or load id");
                }

            }
        }
    }
}