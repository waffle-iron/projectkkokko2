using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class NeedInputReactiveSystem : ReactiveSystem<InputEntity>
{
    private readonly GameContext _game;
    private readonly CommandContext _cmd;

    public NeedInputReactiveSystem (Contexts contexts) : base(contexts.input)
    {
        _game = contexts.game;
        _cmd = contexts.command;
    }

    protected override ICollector<InputEntity> GetTrigger (IContext<InputEntity> context)
    {
        //return collector
        return context.CreateCollector(InputMatcher.AllOf(InputMatcher.Action, InputMatcher.TargetNeed, InputMatcher.Reset));
    }

    protected override bool Filter (InputEntity entity)
    {
        // check for required components
        return entity.hasAction && entity.hasTargetNeed && entity.hasReset;
    }

    protected override void Execute (List<InputEntity> entities)
    {
        foreach (var e in entities)
        {
            var target = _game.GetEntityWithNeed(e.targetNeed.type);
            if (target != null && target.isAnimating == false &&
                target.hasTargetNeed && target.hasTrigger && target.trigger.state == true
                && target.need.action == e.action.type)
            {
                //check the need our triggered needs deducts
                var targetOftarget = _game.GetEntityWithNeed(target.targetNeed.type);
                if (targetOftarget != null && targetOftarget.hasCurrent && targetOftarget.hasMax)
                {
                    var cmdEntity = _cmd.CreateEntity();
                    cmdEntity.AddTargetNeed(e.targetNeed.type);
                    cmdEntity.AddReset(e.reset.restoreAmount);
                    if (e.hasNeedRecoveryModifier)
                    {
                        cmdEntity.AddNeedRecoveryModifier(e.needRecoveryModifier.value);
                    }
                }
            }
        }
    }
}