using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class PreviewInputReactiveSystem : ReactiveSystem<InputEntity>
{
    private readonly CommandContext _cmd;
    private readonly GameContext _game;
    private readonly InputContext _input;

    public PreviewInputReactiveSystem (Contexts contexts) : base(contexts.input)
    {
        _cmd = contexts.command;
        _game = contexts.game;
        _input = contexts.input;
    }

    protected override ICollector<InputEntity> GetTrigger (IContext<InputEntity> context)
    {
        //return collector
        return context.CreateCollector(InputMatcher.AllOf(InputMatcher.TargetEntityID, InputMatcher.Preview));
    }

    protected override bool Filter (InputEntity entity)
    {
        // check for required components
        return entity.hasTargetEntityID && entity.isPreview;
    }

    protected override void Execute (List<InputEntity> entities)
    {
        foreach (var e in entities)
        {
            // do stuff to the matched entities
            var target = _game.GetEntityWithID(e.targetEntityID.value);
            if (target != null && (target.hasAccessory || target.hasFood || target.hasApartmentItem) && target.isPreview == false)
            {
                var cmdEntity = _cmd.CreateEntity();
                cmdEntity.AddTargetEntityID(e.targetEntityID.value);
                cmdEntity.isPreview = true;

                if (target.isPurchased)
                {
                    var inputEntity = _input.CreateEntity();
                    inputEntity.AddTargetEntityID(e.targetEntityID.value);
                    inputEntity.isEquipped = true;
                }
            }
        }
    }
}