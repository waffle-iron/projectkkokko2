using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class EquipCommandReactiveSystem : ReactiveSystem<CommandEntity>
{
    private readonly GameContext _game;
    private IGroup<GameEntity> _accessories;

    public EquipCommandReactiveSystem (Contexts contexts) : base(contexts.command)
    {
        _game = contexts.game;
        _accessories = _game.GetGroup(GameMatcher.AllOf(GameMatcher.Accessory, GameMatcher.Equipped));
    }

    protected override ICollector<CommandEntity> GetTrigger (IContext<CommandEntity> context)
    {
        //return collector
        return context.CreateCollector(CommandMatcher.AllOf(CommandMatcher.TargetEntityID, CommandMatcher.Equipped));
    }

    protected override bool Filter (CommandEntity entity)
    {
        // check for required components
        return entity.isEquipped && entity.hasTargetEntityID;
    }

    protected override void Execute (List<CommandEntity> entities)
    {
        foreach (var e in entities)
        {
            var target = _game.GetEntityWithID(e.targetEntityID.value);

            foreach (var other in _accessories.GetEntities())
            {
                if (other.accessory.type == target.accessory.type)
                {
                    other.isEquipped = false;
                }
            }

            target.isEquipped = true;
        }
    }
}