using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class CommandLoadSceneCompleteSystem : ReactiveSystem<CommandEntity>
{
    private readonly GameContext _game;

    public CommandLoadSceneCompleteSystem (Contexts contexts) : base(contexts.command)
    {
        _game = contexts.game;
    }

    protected override ICollector<CommandEntity> GetTrigger (IContext<CommandEntity> context)
    {
        //return collector
        return context.CreateCollector(CommandMatcher.LoadSceneComplete);
    }

    protected override bool Filter (CommandEntity entity)
    {
        // check for required components
        return entity.isLoadSceneComplete;
    }

    protected override void Execute (List<CommandEntity> entities)
    {
        foreach (var e in entities)
        {
            _game.loadSceneEntity.isToDestroy = true;
            _game.loadSceneEntity.RemoveLoadScene();
        }
    }
}