using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class CommandPauseReactiveSystem : ReactiveSystem<CommandEntity>
{
    private readonly GameContext _game;

    public CommandPauseReactiveSystem (Contexts contexts) : base(contexts.command)
    {
        _game = contexts.game;
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

    
}