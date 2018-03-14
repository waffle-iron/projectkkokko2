using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class NeedInputSwitchReactiveSystem : ReactiveSystem<InputEntity>
{
    private readonly GameContext _game;
    private readonly MetaContext _meta;

    public NeedInputSwitchReactiveSystem (Contexts contexts) : base(contexts.input)
    {
        _game = contexts.game;
        _meta = contexts.meta;
    }

    protected override ICollector<InputEntity> GetTrigger (IContext<InputEntity> context)
    {
        //return collector
        return context.CreateCollector(InputMatcher.AllOf(InputMatcher.Action).NoneOf(InputMatcher.Reset));
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
            // do stuff to the matched entities
            if (e.action.type == ActionType.SHOP)
            {
                var target = _game.GetEntityWithNeed(NeedType.MOOD);
                if (IsValid(target))
                {
                    _meta.entityService.instance.Get(EntityCfgID.SHOP_SWITCH_INPUT);
                }
            }
            else if (e.action.type == ActionType.JOB)
            {
                var target = _game.GetEntityWithNeed(NeedType.HEALTH);
                if (IsValid(target))
                {
                    _meta.entityService.instance.Get(EntityCfgID.JOB_SWITCH_INPUT);
                }
            }
        }
    }

    bool IsValid (GameEntity target)
    {
        return target != null && target.hasMinRequirement && target.current.amount >= target.minRequirement.value;
    }
}