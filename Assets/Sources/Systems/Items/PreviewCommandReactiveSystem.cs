using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class PreviewCommandReactiveSystem : ReactiveSystem<CommandEntity>
{
    private readonly GameContext _game;
    private IGroup<GameEntity> _accessories;

    public PreviewCommandReactiveSystem (Contexts contexts) : base(contexts.command)
    {
        _game = contexts.game;
        _accessories = _game.GetGroup(GameMatcher.AllOf(GameMatcher.Accessory, GameMatcher.Preview));
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
                if (other.accessory.type == target.accessory.type)
                {
                    other.isPreview = false;
                }
            }

            target.isPreview = true;
        }
    }
}