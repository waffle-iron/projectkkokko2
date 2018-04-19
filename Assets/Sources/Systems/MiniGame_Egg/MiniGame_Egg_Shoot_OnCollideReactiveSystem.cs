﻿using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class MiniGame_Egg_Shoot_OnCollideReactiveSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _game;
    private readonly InputContext _input;

    public MiniGame_Egg_Shoot_OnCollideReactiveSystem (Contexts contexts) : base(contexts.game)
    {
        _game = contexts.game;
        _input = contexts.input;
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collector
        return context.CreateCollector(GameMatcher.OnCollision);
    }

    protected override bool Filter (GameEntity entity)
    {
        // check for required components
        return
            _game.hasGameState &&
            _game.gameState.current.IsEqualTo(MiniGameEggState.SHOOT) &&
            entity.hasOnCollision && 
            entity.onCollision.data[0].Type == CollisionType.ENTER &&
            entity.isObstacle;
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            // do stuff to the matched entities
            var target = _game.GetEntityWithID(e.onCollision.data[0].ID);

            if (target != null && target.isBall)
            {
                var inputety = _input.CreateEntity();
                inputety.AddGameState(new GameState(MiniGameEggState.MISSED));
            }
        }
    }
}