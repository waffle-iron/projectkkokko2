using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class InputLoadEntitySystem : ReactiveSystem<InputEntity>
{
    private readonly GameContext _game;
    private readonly InputContext _input;
    private readonly CommandContext _cmd;

    public InputLoadEntitySystem (Contexts contexts) : base(contexts.input)
    {
        _input = contexts.input;
        _game = contexts.game;
        _cmd = contexts.command;
    }

    protected override ICollector<InputEntity> GetTrigger (IContext<InputEntity> context)
    {
        //return collector
        return context.CreateCollector(InputMatcher.Load);
    }

    protected override bool Filter (InputEntity entity)
    {
        // check for required components
        return entity.hasLoad && entity.load.createNew;
    }

    protected override void Execute (List<InputEntity> entities)
    {
        foreach (var e in entities)
        {
            var cmdEty = _cmd.CreateEntity();
            cmdEty.AddLoad(e.load.id, e.load.createNew);
        }
    }
}