using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class PreviewCommandReactiveSystem : ReactiveSystem<CommandEntity>
{
    private readonly GameContext _game;
    private IGroup<GameEntity> _accessories;
    private IGroup<GameEntity> _foods;
    private IGroup<GameEntity> _apartmentItems;

    public PreviewCommandReactiveSystem (Contexts contexts) : base(contexts.command)
    {
        _game = contexts.game;
        _accessories = _game.GetGroup(GameMatcher.AllOf(GameMatcher.Accessory, GameMatcher.Preview));
        _foods = _game.GetGroup(GameMatcher.AllOf(GameMatcher.Food, GameMatcher.Preview));
        _apartmentItems = _game.GetGroup(GameMatcher.AllOf(GameMatcher.ApartmentItem, GameMatcher.Preview));
    }

    protected override ICollector<CommandEntity> GetTrigger (IContext<CommandEntity> context)
    {
        //return collector
        return context.CreateCollector(CommandMatcher.AllOf(CommandMatcher.TargetEntityID, CommandMatcher.Preview));
    }

    protected override bool Filter (CommandEntity entity)
    {
        // check for required components
        return entity.hasTargetEntityID && entity.isPreview;
    }

    protected override void Execute (List<CommandEntity> entities)
    {
        foreach (var e in entities)
        {
            var target = _game.GetEntityWithID(e.targetEntityID.value);

            foreach (var other in _accessories.GetEntities())
            {
                if (target.hasAccessory)
                {
                    if (other.accessory.type == target.accessory.type)
                    {
                        other.isPreview = false;
                    }
                }
                else
                {
                    other.isPreview = false;
                }
            }

            foreach (var other in _foods.GetEntities())
            {
                other.isPreview = false;
            }

            foreach (var other in _apartmentItems.GetEntities())
            {
                other.isPreview = false;
            }

            target.isPreview = true;
        }
    }
}