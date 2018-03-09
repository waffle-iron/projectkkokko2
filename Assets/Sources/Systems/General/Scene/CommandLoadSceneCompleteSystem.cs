﻿using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class CommandLoadSceneCompleteSystem : ReactiveSystem<CommandEntity>
{
    private readonly GameContext _game;
    private readonly MetaContext _meta;

    public CommandLoadSceneCompleteSystem (Contexts contexts) : base(contexts.command)
    {
        _game = contexts.game;
        _meta = contexts.meta;
    }

    protected override ICollector<CommandEntity> GetTrigger (IContext<CommandEntity> context)
    {
        //return collector
        return context.CreateCollector(CommandMatcher.LoadSceneComplete);
    }

    protected override bool Filter (CommandEntity entity)
    {
        // check for required components
        return entity.isLoadSceneComplete;
    }

    protected override void Execute (List<CommandEntity> entities)
    {
        foreach (var e in entities)
        {
            _meta.viewService.instance.Refresh("", true);
            _game.loadSceneEntity.isToDestroy = true;
            _game.loadSceneEntity.RemoveLoadScene();
        }
    }
}