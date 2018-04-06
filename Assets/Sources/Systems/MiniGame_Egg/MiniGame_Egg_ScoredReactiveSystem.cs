using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine;
using Entitas;

public class MiniGame_Egg_ScoredReactiveSystem : ReactiveSystem<GameEntity>
{
    private readonly InputContext _input;
    private readonly IGroup<GameEntity> _coinSpawner;

    public MiniGame_Egg_ScoredReactiveSystem (Contexts contexts) : base(contexts.game)
    {
        _input = contexts.input;
        _coinSpawner = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Spawn, GameMatcher.Score, GameMatcher.Coin));
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
            entity.gameState.current.IsEqualTo(MiniGameEggState.SCORED);
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            //add counter
            //update spawn coin score counter
            //foreach (var spawn in _coinSpawner.GetEntities())
            //{
            //    var inputEty = _input.CreateEntity();

            //    inputEty.AddTargetEntityID(spawn.iD.value);
            //    inputEty.AddChangeScore(spawn.coin.value, spawn.coin.operation);
            //}

            // do stuff to the matched entities
            var inputety = _input.CreateEntity();
            inputety.AddGameState(new GameState(MiniGameEggState.SETUP_GAME));
        }
    }
}