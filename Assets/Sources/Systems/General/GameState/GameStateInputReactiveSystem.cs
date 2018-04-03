using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class GameStateInputReactiveSystem : ReactiveSystem<InputEntity>
{
    private readonly GameContext _game;
    private readonly InputContext _input;
    private readonly CommandContext _cmd;

    public GameStateInputReactiveSystem (Contexts contexts) : base(contexts.input)
    {
        _input = contexts.input;
        _game = contexts.game;
        _cmd = contexts.command;
    }

    protected override ICollector<InputEntity> GetTrigger (IContext<InputEntity> context)
    {
        //return collector
        return context.CreateCollector(InputMatcher.GameState);
    }

    protected override bool Filter (InputEntity entity)
    {
        // check for required components
        return entity.hasGameState;
    }

    protected override void Execute (List<InputEntity> entities)
    {
        foreach (var e in entities)
        {
            if (_game.hasGameState && _game.gameState.state != e.gameState.state)
            {
                var cmd = _cmd.CreateEntity();
                cmd.AddGameState(e.gameState.state, e.gameState.stateType);
            }
        }
    }
}