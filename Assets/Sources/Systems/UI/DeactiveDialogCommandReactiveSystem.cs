using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class DeactiveDialogCommandReactiveSystem : ReactiveSystem<CommandEntity>
{
    private readonly GameContext _game;

    public DeactiveDialogCommandReactiveSystem (Contexts contexts) : base(contexts.command)
    {
        _game = contexts.game;
    }

    protected override ICollector<CommandEntity> GetTrigger (IContext<CommandEntity> context)
    {
        //return collector
        return context.CreateCollector(CommandMatcher.AllOf(CommandMatcher.DeactivateDialog));
    }

    protected override bool Filter (CommandEntity entity)
    {
        // check for required components
        return entity.hasDeactivateDialog;
    }

    protected override void Execute (List<CommandEntity> entities)
    {
        foreach (var e in entities)
        {
            // do stuff to the matched entities
            var target = _game.GetEntityWithDialogId(e.deactivateDialog.id);
            target.RemoveActiveDialog();
        }
    }
}