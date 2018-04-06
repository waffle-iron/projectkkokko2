using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class UpdateHighScoreReactiveSystem : ReactiveSystem<GameEntity>
{
    public UpdateHighScoreReactiveSystem (Contexts contexts) : base(contexts.game)
    {
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collector
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Score, GameMatcher.TopScore));
    }

    protected override bool Filter (GameEntity entity)
    {
        // check for required components
        return entity.hasScore && entity.hasTopScore;
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            if (e.topScore.value < e.score.value)
            {
                e.ReplaceTopScore(e.score.value);
            }
        }
    }
}