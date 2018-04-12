using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class ChangeHudInputReactiveSystem : ReactiveSystem<InputEntity>
{
    private readonly GameContext _game;
    private readonly InputContext _input;
    private readonly CommandContext _cmd;

    public ChangeHudInputReactiveSystem (Contexts contexts) : base(contexts.input)
    {
        _input = contexts.input;
        _game = contexts.game;
        _cmd = contexts.command;
    }

    protected override ICollector<InputEntity> GetTrigger (IContext<InputEntity> context)
    {
        //return collector
        return context.CreateCollector(InputMatcher.AllOf(InputMatcher.HudChangeState));
    }

    protected override bool Filter (InputEntity entity)
    {
        // check for required components
        return entity.hasHudChangeState;
    }

    protected override void Execute (List<InputEntity> entities)
    {
        foreach (var e in entities)
        {
            if (e.hudChangeState.all)
            {
                var cmdEty = _cmd.CreateEntity();
                cmdEty.AddHudChangeState(e.hudChangeState.newState, e.hudChangeState.all);
            }
            else if (e.hudChangeState.all == false && e.hasTargetEntityID)
            {
                // do stuff to the matched entities
                var target = _game.GetEntityWithID(e.targetEntityID.value);

                if (target != null && target.hasHud)
                {
                    var cmdEty = _cmd.CreateEntity();
                    cmdEty.AddTargetEntityID(e.targetEntityID.value);
                    cmdEty.AddHudChangeState(e.hudChangeState.newState, e.hudChangeState.all);
                }
            }

        }
    }
}