using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class CommandLoadSceneSystem : ReactiveSystem<CommandEntity>
{
    private readonly GameContext _game;
    private readonly MetaContext _meta;
    private readonly IGroup<GameEntity> _toDestroy;

    public CommandLoadSceneSystem (Contexts contexts) : base(contexts.command)
    {
        _game = contexts.game;
        _meta = contexts.meta;
        _toDestroy = _game.GetGroup(GameMatcher.AllOf(GameMatcher.ID).NoneOf(GameMatcher.DoNotDestroyOnSceneChange));
    }

    protected override ICollector<CommandEntity> GetTrigger (IContext<CommandEntity> context)
    {
        //return collector
        return context.CreateCollector(CommandMatcher.LoadScene);
    }

    protected override bool Filter (CommandEntity entity)
    {
        // check for required components
        return entity.hasLoadScene;
    }

    protected override void Execute (List<CommandEntity> entities)
    {
        foreach (var e in entities)
        {
            _meta.loadSceneService.instance.LoadScene(e.loadScene.name);
            var entity = _game.CreateEntity();
            entity.AddLoadScene(e.loadScene.name);
            entity.isDoNotDestroyOnSceneChange = true;
        }

        foreach (var e in _toDestroy.GetEntities())
        {
            e.isToDestroy = true;
        }

        _meta.viewService.instance.Clear();
    }
}