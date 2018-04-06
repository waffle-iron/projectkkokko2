using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class ActivateDialogCommandSystem : ReactiveSystem<CommandEntity>
{
    private readonly GameContext _game;
    private readonly InputContext _input;
    private readonly IGroup<GameEntity> _active;

    public ActivateDialogCommandSystem (Contexts contexts) : base(contexts.command)
    {
        _game = contexts.game;
        _input = contexts.input;
        _active = _game.GetGroup(GameMatcher.ActiveDialog);
    }

    protected override ICollector<CommandEntity> GetTrigger (IContext<CommandEntity> context)
    {
        //return collector
        return context.CreateCollector(CommandMatcher.AllOf(CommandMatcher.ActiveDialog));
    }

    protected override bool Filter (CommandEntity entity)
    {
        // check for required components
        return entity.hasActiveDialog;
    }

    protected override void Execute (List<CommandEntity> entities)
    {
        foreach (var e in entities)
        {
            foreach (var ac in _active.GetEntities())
            {
                ac.RemoveActiveDialog();
            }

            var target = _game.GetEntityWithDialogId(e.activeDialog.id);
            target.AddActiveDialog(e.activeDialog.id);

            var inputEty = _input.CreateEntity();
            inputEty.AddPause(target.dialog.isPause);

        }
    }
}