using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System.Linq;
using Entitas;

public class MiniGame_Egg_ShootExecuteSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _scoredHoops;
    private readonly GameContext _game;
    private readonly InputContext _input;

    public MiniGame_Egg_ShootExecuteSystem (Contexts contexts)
    {
        _game = contexts.game;
        _input = contexts.input;
        _scoredHoops = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Basket, GameMatcher.Tag, GameMatcher.TargetTag, GameMatcher.Collidable, GameMatcher.OnCollision));
    }

    public void Execute ()
    {
        if (_game.hasGameState && _game.gameState.current.IsEqualTo(MiniGameEggState.SHOOT))
        {
            var scored = _scoredHoops?.GetEntities()
                .Select(hoop =>
                {
                    var target = _game.GetEntityWithID(hoop.onCollision.otherID);
                    if (target.hasTag) { if (hoop.targetTag.current.Any(tag => target.tag.current == tag)) { return true; } }

                    return false;
                }).Any(result => result == true);

            if (scored != null && scored == true)
            {
                var inputety = _input.CreateEntity();
                inputety.AddGameState(new GameState(MiniGameEggState.SCORED));
            }
        }
    }
}