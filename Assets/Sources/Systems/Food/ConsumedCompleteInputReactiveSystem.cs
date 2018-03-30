using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class ConsumedCompleteInputReactiveSystem : ReactiveSystem<InputEntity>
{
    private readonly GameContext _game;
    private readonly InputContext _input;
    private readonly CommandContext _cmd;

    public ConsumedCompleteInputReactiveSystem (Contexts contexts) : base(contexts.input)
    {
        _input = contexts.input;
        _game = contexts.game;
        _cmd = contexts.command;
    }

    protected override ICollector<InputEntity> GetTrigger (IContext<InputEntity> context)
    {
        //return collector
        return context.CreateCollector(InputMatcher.AllOf(InputMatcher.TargetEntityID, InputMatcher.Consumed));
    }

    protected override bool Filter (InputEntity entity)
    {
        // check for required components
        return entity.hasTargetEntityID && entity.isConsumed;
    }

    protected override void Execute (List<InputEntity> entities)
    {
        foreach (var e in entities)
        {
            var target = _game.GetEntityWithID(e.targetEntityID.value);

            if (target != null && target.hasConsuming &&  target.hasFood && target.hasTargetEntityID)
            {
                var cmdEty = _cmd.CreateEntity();
                cmdEty.AddTargetEntityID(e.targetEntityID.value);
                cmdEty.isConsumed = true;
            }
        }
    }
}