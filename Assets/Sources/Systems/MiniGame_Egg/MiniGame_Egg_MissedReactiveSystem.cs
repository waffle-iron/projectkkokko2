using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class MiniGame_Egg_MissedReactiveSystem : ReactiveSystem<GameEntity>
{
    private readonly InputContext _input;

    public MiniGame_Egg_MissedReactiveSystem (Contexts contexts) : base(contexts.game)
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
            entity.gameState.current.IsEqualTo(MiniGameEggState.MISSED);
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            // do stuff to the matched entities
            var inputety = _input.CreateEntity();
            inputety.AddGameState(new GameState(MiniGameEggState.RESULTS));
        }
    }
}