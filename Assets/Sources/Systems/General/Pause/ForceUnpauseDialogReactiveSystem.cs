using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class ForceUnpauseDialogReactiveSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _game;
    private readonly InputContext _input;

    public ForceUnpauseDialogReactiveSystem (Contexts contexts) : base(contexts.game)
    {
        _game = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collector
        return context.CreateCollector(GameMatcher.ActiveDialog.Removed());
    }

    protected override bool Filter (GameEntity entity)
    {
        // check for required components
        return true;
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            // do stuff to the matched entities
            var inputEty = _input.CreateEntity();
            inputEty.AddPause(false);
        }
    }
}