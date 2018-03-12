using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class CommandSaveLoadReactiveSystem : ReactiveSystem<CommandEntity>
{
    private readonly GameContext _game;
    private readonly MetaContext _meta;
    private readonly Contexts _contexts;

    public CommandSaveLoadReactiveSystem (Contexts contexts) : base(contexts.command)
    {
        _game = contexts.game;
        _meta = contexts.meta;
        _contexts = contexts;
    }

    protected override ICollector<CommandEntity> GetTrigger (IContext<CommandEntity> context)
    {
        //return collector
        return context.CreateCollector(CommandMatcher.AllOf(CommandMatcher.TargetEntityID).AnyOf(CommandMatcher.Save, CommandMatcher.Load));
    }

    protected override bool Filter (CommandEntity entity)
    {
        // check for required components
        return entity.hasTargetEntityID;
    }

    protected override void Execute (List<CommandEntity> entities)
    {
        var saveService = _meta.saveService.instance;

        foreach (var e in entities)
        {
            // do stuff to the matched entities
            var entity = _game.GetEntityWithID(e.targetEntityID.value);

            if (e.hasSave)
            {
                entity.isSaving = true;
                saveService.Save(e.save.id, entity);
            }
            if (e.hasLoad)
            {
                entity.isLoading = true;
                if (e.load.createNew)
                {
                    entity.isToDestroy = true;
                    saveService.LoadNew(e.load.id, _contexts);
                }
                else
                {
                    saveService.LoadExisting(e.load.id, entity);
                }
            }
        }
    }
}