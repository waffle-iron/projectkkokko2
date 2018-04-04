using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class MiniGameEgg_SetupGameReactiveSystem : ReactiveSystem<GameEntity>
{
    private readonly InputContext _input;
    private IGroup<GameEntity> _hoops;
    private IGroup<GameEntity> _balls;

    private List<GameEntity> _hoopBuffer = new List<GameEntity>();
    private List<GameEntity> _ballsBuffer = new List<GameEntity>();

    public MiniGameEgg_SetupGameReactiveSystem (Contexts contexts) : base(contexts.game)
    {
        _input = contexts.input;
        _hoops = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.OnCollision, GameMatcher.Basket));
        _balls = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.OnCollision, GameMatcher.Ball));
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
            entity.gameState.current.IsEqualTo(MiniGameEggState.SETUP_GAME);
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            //set ball in starting position (all done in view)
            //randomize position of basketball ring (all done in view)
            foreach (var ball in _balls.GetEntities(_ballsBuffer)) { ball.RemoveOnCollision(); }
            foreach (var hoop in _hoops.GetEntities(_hoopBuffer)) { hoop.RemoveOnCollision(); }

            var inputEty = _input.CreateEntity();
            inputEty.AddGameState(new GameState(MiniGameEggState.START_GAME));
        }
    }
}