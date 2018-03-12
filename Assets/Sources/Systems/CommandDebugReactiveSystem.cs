﻿using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class CommandDebugReactiveSystem : ReactiveSystem<CommandEntity>
{
    private readonly MetaContext _meta;
    private readonly GameContext _game;

    public CommandDebugReactiveSystem(Contexts contexts) : base(contexts.command)
    {
        _meta = contexts.meta;
        _game = contexts.game;
    }

    protected override ICollector<CommandEntity> GetTrigger(IContext<CommandEntity> context)
    {
        //return collector
        return context.CreateCollector(CommandMatcher.Debug);
    }

    protected override bool Filter(CommandEntity entity)
    {
        // check for required components
        return entity.hasDebug;
    }

    protected override void Execute(List<CommandEntity> entities)
    {
        foreach (var e in entities)
        {
            _meta.debugService.instance.Log(e.debug.value);
            _game.CreateEntity().AddDebug(e.debug.value);
        }
    }
}