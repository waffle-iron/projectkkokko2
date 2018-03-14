using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class EquippedListReactiveSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _game;
    private readonly InputContext _input;

    public EquippedListReactiveSystem (Contexts contexts) : base(contexts.game)
    {
        _game = contexts.game;
        _input = contexts.input;
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collector
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Accessory).AnyOf(GameMatcher.Equipped).AddedOrRemoved());
    }

    protected override bool Filter (GameEntity entity)
    {
        // check for required components
        return entity.hasAccessory;
    }

    protected override void Execute (List<GameEntity> entities)
    {
        var accessories = _game.equippedItems._accessoryList;
        foreach (var e in entities)
        {
            if (e.isEquipped)
            {
                if (accessories.Contains(e.accessory.id) == false)
                {
                    accessories.Add(e.accessory.id);
                    Save(_game.equippedItemsEntity);
                }
            }
            else
            {
                if (accessories.Contains(e.accessory.id))
                {
                    accessories.Remove(e.accessory.id);
                    Save(_game.equippedItemsEntity);
                }
            }
        }
    }

    void Save (GameEntity target)
    {
        var inputEntity = _input.CreateEntity();
        inputEntity.AddTargetEntityID(target.iD.value);
        inputEntity.isSave = true;
    }
}