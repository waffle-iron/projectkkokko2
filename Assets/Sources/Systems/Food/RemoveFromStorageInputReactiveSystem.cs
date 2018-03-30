using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class RemoveFromStorageInputReactiveSystem : ReactiveSystem<InputEntity>
{
    private readonly GameContext _game;
    private readonly InputContext _input;
    private readonly CommandContext _cmd;

    public RemoveFromStorageInputReactiveSystem (Contexts contexts) : base(contexts.input)
    {
        _input = contexts.input;
        _game = contexts.game;
        _cmd = contexts.command;
    }

    protected override ICollector<InputEntity> GetTrigger (IContext<InputEntity> context)
    {
        //return collector
        return context.CreateCollector(InputMatcher.AllOf(InputMatcher.RemoveFromStorage, InputMatcher.TargetEntityID));
    }

    protected override bool Filter (InputEntity entity)
    {
        // check for required components
        return entity.isRemoveFromStorage && entity.hasTargetEntityID;
    }

    protected override void Execute (List<InputEntity> entities)
    {
        foreach (var e in entities)
        {
            var target = _game.GetEntityWithID(e.targetEntityID.value);
            if (target != null && target.hasFood && target.isRemoveFromStorage == false)
            {
                var cmdEty = _cmd.CreateEntity();
                cmdEty.AddTargetEntityID(e.targetEntityID.value);
                cmdEty.isRemoveFromStorage = true;
            }
        }
    }
}