using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class DeactiveDialogInputReactiveSystem : ReactiveSystem<InputEntity>
{
    private readonly GameContext _game;
    private readonly InputContext _input;
    private readonly CommandContext _cmd;

    public DeactiveDialogInputReactiveSystem (Contexts contexts) : base(contexts.input)
    {
        _input = contexts.input;
        _game = contexts.game;
        _cmd = contexts.command;
    }

    protected override ICollector<InputEntity> GetTrigger (IContext<InputEntity> context)
    {
        //return collector
        return context.CreateCollector(InputMatcher.AllOf(InputMatcher.DeactivateDialog));
    }

    protected override bool Filter (InputEntity entity)
    {
        // check for required components
        return entity.hasDeactivateDialog;
    }

    protected override void Execute (List<InputEntity> entities)
    {
        foreach (var e in entities)
        {
            // do stuff to the matched entities
            var target = _game.GetEntityWithDialogId(e.deactivateDialog.id);

            if (target != null && target.hasActiveDialog)
            {
                var cmdEty = _cmd.CreateEntity();
                cmdEty.AddDeactivateDialog(e.deactivateDialog.id);

            }
        }
    }
}