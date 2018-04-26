﻿using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class ConsumedCompleteCommandReactiveSystem : ReactiveSystem<CommandEntity>
{
    private readonly GameContext _game;
    private readonly MetaContext _meta;
    private readonly InputContext _input;

    private const string HUNGER_ACTION_ENTITY = "ACTION_EAT_INPUT";

    public ConsumedCompleteCommandReactiveSystem (Contexts contexts) : base(contexts.command)
    {
        _game = contexts.game;
        _meta = contexts.meta;
        _input = contexts.input;
    }

    protected override ICollector<CommandEntity> GetTrigger (IContext<CommandEntity> context)
    {
        //return collector
        return context.CreateCollector(CommandMatcher.AllOf(CommandMatcher.TargetEntityID, CommandMatcher.Consumed));
    }

    protected override bool Filter (CommandEntity entity)
    {
        // check for required components
        return entity.hasTargetEntityID && entity.isConsumed;
    }

    protected override void Execute (List<CommandEntity> entities)
    {
        foreach (var e in entities)
        {
            // do stuff to the matched entities
            var target = _game.GetEntityWithID(e.targetEntityID.value);

            if (target != null && target.hasFood)
            {
                IEntity hungerReset;
                _meta.entityService.instance.Get(HUNGER_ACTION_ENTITY, out hungerReset);
                ((INeedRecoveryModifierEntity)hungerReset).AddNeedRecoveryModifier(target.food.recovery);

                var consumer = _game.GetEntityWithID(target.consuming.consumerID);
                consumer?.RemoveConsuming();

                var uiFood = _game.GetEntityWithID(target.targetEntityID.value);
                if (uiFood.hasQuantity)
                {
                    var newQtty = uiFood.quantity.value - 1;
                    if (newQtty <= 0)
                    {
                        uiFood.isToDestroy = true;
                        var inputety = _input.CreateEntity();
                        inputety.AddTargetEntityID(uiFood.iD.value);
                        inputety.isSave = true;
                    }
                    else
                    {
                        uiFood.ReplaceQuantity(newQtty);
                        uiFood.isRemoveFromStorage = false;
                        var inputety = _input.CreateEntity();
                        inputety.AddTargetEntityID(uiFood.iD.value);
                        inputety.isSave = true;
                    }
                }
                else { uiFood.isToDestroy = true; }

                target.isToDestroy = true;
            }

        }
    }
}