using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class MiniGameEgg_ResetReactiveSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _game;
    private readonly InputContext _input;

    public MiniGameEgg_ResetReactiveSystem (Contexts contexts) : base(contexts.game)
    {
        _game = contexts.game;
        _input = contexts.input;
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collector
        return context.CreateCollector(GameMatcher.GameState);
    }

    protected override bool Filter (GameEntity entity)
    {
        // check for required components
        return entity.hasGameState &&
                entity.gameState.current.IsEqualTo(MiniGameEggState.RESET_GAME);
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            //set score to 0
            //change state to setup game
            var inputEty = _input.CreateEntity();
            inputEty.AddChangeScore(0, OperationType.REPLACE);
            inputEty.AddGameState(new GameState(MiniGameEggState.SETUP_GAME));
        }
    }
}