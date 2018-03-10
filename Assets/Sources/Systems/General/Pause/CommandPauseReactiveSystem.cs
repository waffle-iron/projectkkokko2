using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class CommandPauseReactiveSystem : ReactiveSystem<CommandEntity>, IInitializeSystem
{
    private readonly GameContext _game;
    private readonly MetaContext _meta;
    private const string PAUSE_ENTITY = "pause";

    public CommandPauseReactiveSystem (Contexts contexts) : base(contexts.command)
    {
        _game = contexts.game;
        _meta = contexts.meta;
    }

    protected override ICollector<CommandEntity> GetTrigger (IContext<CommandEntity> context)
    {
        //return collector
        return context.CreateCollector(CommandMatcher.Pause);
    }

    protected override bool Filter (CommandEntity entity)
    {
        // check for required components
        return entity.hasPause;
    }

    protected override void Execute (List<CommandEntity> entities)
    {
        foreach (var e in entities)
        {
            _game.ReplacePause(e.pause.state);
        }
    }

    public void Initialize ()
    {
        IEntity entity;
        if (_meta.entityService.instance.Get(PAUSE_ENTITY, out entity))
        {
            //do something when not found
        }
    }
}