using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class ScoreCommandReactiveSystem : ReactiveSystem<CommandEntity>
{
    private readonly GameContext _game;

    public ScoreCommandReactiveSystem (Contexts contexts) : base(contexts.command)
    {
        _game = contexts.game;
    }

    protected override ICollector<CommandEntity> GetTrigger (IContext<CommandEntity> context)
    {
        //return collector
        return context.CreateCollector(CommandMatcher.AllOf(CommandMatcher.TargetEntityID, CommandMatcher.ChangeScore));
    }

    protected override bool Filter (CommandEntity entity)
    {
        // check for required components
        return entity.hasChangeScore && entity.hasTargetEntityID;
    }

    protected override void Execute (List<CommandEntity> entities)
    {
        foreach (var e in entities)
        {
            // do stuff to the matched entities
            var target = _game.GetEntityWithID(e.targetEntityID.value);

            switch (e.changeScore.operation)
            {
                case OperationType.ADD:
                    target.ReplaceScore(target.score.value + e.changeScore.value);
                    break;
                case OperationType.REDUCE:
                    target.ReplaceScore(target.score.value - e.changeScore.value);
                    break;
                case OperationType.REPLACE:
                    target.ReplaceScore(e.changeScore.value);
                    break;
            }
        }
    }
}