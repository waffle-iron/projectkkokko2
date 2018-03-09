using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class InputLoadSceneSystem : ReactiveSystem<InputEntity>
{
    private readonly GameContext _game;
    private readonly CommandContext _command;

    public InputLoadSceneSystem (Contexts contexts) : base(contexts.input)
    {
        _game = contexts.game;
        _command = contexts.command;
    }

    protected override ICollector<InputEntity> GetTrigger (IContext<InputEntity> context)
    {
        //return collector
        return context.CreateCollector(InputMatcher.LoadScene.Added());
    }

    protected override bool Filter (InputEntity entity)
    {
        // check for required components
        return entity.hasLoadScene;
    }

    protected override void Execute (List<InputEntity> entities)
    {
        foreach (var e in entities)
        {
            if (_game.hasLoadScene == false)
            {
                _command.SetLoadScene(e.loadScene.name);
            }
        }
    }
}