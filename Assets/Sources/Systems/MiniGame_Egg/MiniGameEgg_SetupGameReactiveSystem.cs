using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class MiniGameEgg_SetupGameReactiveSystem : ReactiveSystem<GameEntity>
{
    private readonly InputContext _input;

    public MiniGameEgg_SetupGameReactiveSystem (Contexts contexts) : base(contexts.game)
    {
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
            entity.gameState.current.type == typeof(MiniGameEggState) &&
            entity.gameState.current.state == (int)MiniGameEggState.SETUP_GAME;
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            //set ball in starting position (all done in view)
            //randomize position of basketball ring (all done in view)
            var inputEty = _input.CreateEntity();
            inputEty.AddChangeScore(0, OperationType.REPLACE);
            inputEty.AddGameState(new GameState((int)MiniGameEggState.START_GAME, typeof(MiniGameEggState)));
        }
    }
}