using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class CommandRemoveFromStorageReactiveSystem : ReactiveSystem<CommandEntity>
{
    private readonly GameContext _game;
    private readonly MetaContext _meta;

    public CommandRemoveFromStorageReactiveSystem (Contexts contexts) : base(contexts.command)
    {
        _game = contexts.game;
        _meta = contexts.meta;
    }

    protected override ICollector<CommandEntity> GetTrigger (IContext<CommandEntity> context)
    {
        //return collector
        return context.CreateCollector(CommandMatcher.AllOf(CommandMatcher.RemoveFromStorage, CommandMatcher.TargetEntityID));
    }

    protected override bool Filter (CommandEntity entity)
    {
        // check for required components
        return entity.isRemoveFromStorage && entity.hasTargetEntityID;
    }

    protected override void Execute (List<CommandEntity> entities)
    {
        foreach (var e in entities)
        {
            // do stuff to the matched entities
            var target = _game.GetEntityWithID(e.targetEntityID.value);
            target.isRemoveFromStorage = true;

            IEntity entity;
            _meta.entityService.instance.Get("FOOD_INTERACTABLE_GAME", out entity);

            var gameEty = (GameEntity)entity;
            gameEty.AddFood(target.food.id, target.food.recovery);
            gameEty.AddTargetEntityID(target.iD.value);
        }
    }
}