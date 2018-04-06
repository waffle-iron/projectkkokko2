using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class ActivateDialogInputSystem : ReactiveSystem<InputEntity>
{
    private readonly GameContext _game;
    private readonly InputContext _input;
    private readonly CommandContext _cmd;

    public ActivateDialogInputSystem (Contexts contexts) : base(contexts.input)
    {
        _input = contexts.input;
        _game = contexts.game;
        _cmd = contexts.command;
    }

    protected override ICollector<InputEntity> GetTrigger (IContext<InputEntity> context)
    {
        //return collector
        return context.CreateCollector(InputMatcher.AllOf(InputMatcher.ActiveDialog));
    }

    protected override bool Filter (InputEntity entity)
    {
        // check for required components
        return entity.hasActiveDialog;
    }

    protected override void Execute (List<InputEntity> entities)
    {
        foreach (var e in entities)
        {
            // do stuff to the matched entities
            var target = _game.GetEntityWithDialogId(e.activeDialog.id);

            if (target != null && target.hasDialog)
            {
                var cmdEty = _cmd.CreateEntity();
                cmdEty.AddActiveDialog(e.activeDialog.id);

            }
        }
    }
}