﻿using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class CommandSaveLoadReactiveSystem : ReactiveSystem<CommandEntity>, IInitializeSystem
{
    private readonly GameContext _game;
    private readonly MetaContext _meta;
    private readonly Contexts _contexts;

    private const string SAVE_VIEW = "SaveView";
    private const string LOAD_VIEW = "LoadView";

    public CommandSaveLoadReactiveSystem (Contexts contexts) : base(contexts.command)
    {
        _game = contexts.game;
        _meta = contexts.meta;
        _contexts = contexts;
    }

    protected override ICollector<CommandEntity> GetTrigger (IContext<CommandEntity> context)
    {
        //return collector
        return context.CreateCollector(CommandMatcher.AnyOf(CommandMatcher.Save, CommandMatcher.Load));
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
                entity.isToDestroy = true;
                saveService.Save(e.save.id, entity);
            }
            if (e.hasLoad)
            {
                entity.isLoading = true;
                entity.isToDestroy = true;
                if (e.load.createNew)
                {
                    saveService.LoadNew(e.load.id, _contexts);
                }
                else
                {
                    saveService.LoadExisting(e.load.id, entity);
                }
            }
        }
    }

    public void Initialize ()
    {
        _game.CreateEntity().AddView(SAVE_VIEW);
        _game.CreateEntity().AddView(LOAD_VIEW);
    }
}