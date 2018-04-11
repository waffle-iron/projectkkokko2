using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class ChangeHudCommandReactiveSystem : ReactiveSystem<CommandEntity>
{
    private readonly GameContext _game;
    private readonly IGroup<GameEntity> _huds;

    public ChangeHudCommandReactiveSystem (Contexts contexts) : base(contexts.command)
    {
        _game = contexts.game;
        _huds = contexts.game.GetGroup(GameMatcher.Hud);
    }

    protected override ICollector<CommandEntity> GetTrigger (IContext<CommandEntity> context)
    {
        //return collector
        return context.CreateCollector(CommandMatcher.AllOf(CommandMatcher.HudChangeState));
    }

    protected override bool Filter (CommandEntity entity)
    {
        // check for required components
        return entity.hasHudChangeState;
    }

    protected override void Execute (List<CommandEntity> entities)
    {
        foreach (var e in entities)
        {
            if (e.hudChangeState.all)
            {
                foreach (var hud in _huds.GetEntities())
                {
                    hud.ReplaceHud(e.hudChangeState.newState);
                }
            }
            else if (e.hudChangeState.all == false && e.hasTargetEntityID)
            {
                // do stuff to the matched entities
                var target = _game.GetEntityWithID(e.targetEntityID.value);

                target.ReplaceHud(e.hudChangeState.newState);
            }
        }
    }
}