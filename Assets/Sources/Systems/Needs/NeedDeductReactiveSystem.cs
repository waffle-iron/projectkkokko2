﻿using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class NeedDeductReactiveSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _game;
    private readonly InputContext _input;
    private readonly MetaContext _meta;

    public NeedDeductReactiveSystem (Contexts contexts) : base(contexts.game)
    {
        _game = contexts.game;
        _input = contexts.input;
        _meta = contexts.meta;
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collector
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Deductions));
    }

    protected override bool Filter (GameEntity entity)
    {
        // check for required components
        return entity.hasTrigger &&
                entity.trigger.state == true &&
                entity.hasDeplete &&
                entity.hasDeductions &&
                entity.deductions.count > 0;
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            //get target need
            var target = _game.GetEntityWithNeed(e.targetNeed.type);

            if (target != null && (target.hasCurrent && target.hasMax))
            {
                //deduct and clamp
                var deductions = Mathf.Clamp((e.deplete.amount * (int)e.deductions.count), 0, target.max.amount);
                var newValue = target.current.amount - deductions;
                newValue = Mathf.Clamp(newValue, 0, target.max.amount);
                target.ReplaceCurrent(newValue);

                //reset timer
                var inputEntity = _input.CreateEntity();
                inputEntity.AddTargetEntityID(e.iD.value);
                inputEntity.isTimerReset = true;

                _meta.debugService.instance.Log($"{e.need.type} deducts {e.deplete.amount * (int)e.deductions.count} to {target.need.type}");

                //reset deductions
                e.ReplaceDeductions(0);

                e.isNeedForceSave = true;
            }
        }
    }
}