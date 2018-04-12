using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class OverallOsuCheckerReactiveSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _game;
    private readonly InputContext _input;

    public OverallOsuCheckerReactiveSystem (Contexts contexts) : base(contexts.game)
    {
        _game = contexts.game;
        _input = contexts.input;
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collector
        return context.CreateCollector(GameMatcher.HitRangeStatus.Added());
    }

    protected override bool Filter (GameEntity entity)
    {
        // check for required components
        return entity.isOsuHitPoint && entity.hasHitRangeStatus;
    }

    protected override void Execute (List<GameEntity> entities)
    {
        if (_game.hasOsu && _game.osuEntity.hasHit && _game.osuEntity.hasMiss)
        {
            foreach (var e in entities)
            {
                if (e.hitRangeStatus.state == true) { _game.osuEntity.ReplaceHit(_game.osuEntity.hit.count + 1); }
                else if (e.hitRangeStatus.state == false) { _game.osuEntity.ReplaceMiss(_game.osuEntity.miss.count - 1); }
                e.isToDestroy = true;

                if (_game.osuEntity.hit.count == _game.osu.maxHits)
                {
                    var inputety = _input.CreateEntity();
                    inputety.AddCreateEntity(_game.osu.successEntity);
                    _game.osuEntity.isToDestroy = true;
                }
                if (_game.osuEntity.miss.count == _game.osu.maxMisses)
                {
                    var inputety = _input.CreateEntity();
                    inputety.AddCreateEntity(_game.osu.failedEntity);
                    _game.osuEntity.isToDestroy = true;
                }
            }
        }

    }
}