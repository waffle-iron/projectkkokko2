using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class PurchaseCommandReactiveSystem : ReactiveSystem<CommandEntity>
{
    private readonly GameContext _game;
    private readonly InputContext _input;

    public PurchaseCommandReactiveSystem (Contexts contexts) : base(contexts.command)
    {
        _game = contexts.game;
        _input = contexts.input;
    }

    protected override ICollector<CommandEntity> GetTrigger (IContext<CommandEntity> context)
    {
        //return collector
        return context.CreateCollector(CommandMatcher.AllOf(CommandMatcher.TargetEntityID, CommandMatcher.Purchased));
    }

    protected override bool Filter (CommandEntity entity)
    {
        // check for required components
        return entity.hasTargetEntityID && entity.isPurchased;
    }

    protected override void Execute (List<CommandEntity> entities)
    {
        foreach (var e in entities)
        {
            var target = _game.GetEntityWithID(e.targetEntityID.value);
            target.isPurchased = true;

            var saveInputEntity = _input.CreateEntity();
            saveInputEntity.AddTargetEntityID(target.iD.value);
            saveInputEntity.isSave = true;

            var equipInputEntity = _input.CreateEntity();
            equipInputEntity.AddTargetEntityID(target.iD.value);
            equipInputEntity.isEquipped = true;
        }
    }
}