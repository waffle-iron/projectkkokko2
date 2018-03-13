using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class InputActionReactiveSystem : ReactiveSystem<InputEntity>
{
    private readonly GameContext _game;
    private readonly CommandContext _cmd;

    public InputActionReactiveSystem (Contexts contexts) : base(contexts.input)
    {
        _game = contexts.game;
        _cmd = contexts.command;
    }

    protected override ICollector<InputEntity> GetTrigger (IContext<InputEntity> context)
    {
        //return collector
        return context.CreateCollector(InputMatcher.Action);
    }

    protected override bool Filter (InputEntity entity)
    {
        // check for required components
        return entity.hasAction;
    }

    protected override void Execute (List<InputEntity> entities)
    {
        foreach (var e in entities)
        {
           //do checks for actions if needed
        }
    }
}