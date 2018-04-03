using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class ScoreOverallInputReactiveSystem : ReactiveSystem<InputEntity>
{
    private readonly GameContext _game;
    private readonly InputContext _input;
    private readonly CommandContext _cmd;

    private readonly IGroup<GameEntity> _scores;

    public ScoreOverallInputReactiveSystem (Contexts contexts) : base(contexts.input)
    {
        _input = contexts.input;
        _game = contexts.game;
        _cmd = contexts.command;
        _scores = _game.GetGroup(GameMatcher.Score);
    }

    protected override ICollector<InputEntity> GetTrigger (IContext<InputEntity> context)
    {
        //return collector
        return context.CreateCollector(InputMatcher.AllOf(InputMatcher.ChangeScore).NoneOf(InputMatcher.TargetEntityID));
    }

    protected override bool Filter (InputEntity entity)
    {
        // check for required components
        return entity.hasChangeScore;
    }

    protected override void Execute (List<InputEntity> entities)
    {
        foreach (var e in entities)
        {
            // do stuff to the matched entities
            foreach (var score in _scores.GetEntities())
            {
                var cmdEty = _cmd.CreateEntity();
                cmdEty.AddTargetEntityID(score.iD.value);
                cmdEty.AddChangeScore(e.changeScore.value, e.changeScore.operation);
            }
        }
    }
}