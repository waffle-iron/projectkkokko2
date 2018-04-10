using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class CreateEntityInputReactiveSystem : IExecuteSystem
{
    private readonly CommandContext _cmd;
    private readonly GameContext _game;

    private readonly IGroup<InputEntity> _inputs;
    private List<InputEntity> _buffer;

    public CreateEntityInputReactiveSystem (Contexts contexts)
    {
        _cmd = contexts.command;
        _game = contexts.game;
        _inputs = contexts.input.GetGroup(InputMatcher.CreateEntity);
        _buffer = new List<InputEntity>();
    }

    public void Execute ()
    {
        if (_game.isLoadSceneComplete && _game.isLoadedViewsComplete)
        {
            foreach (var e in _inputs.GetEntities(_buffer))
            {
                var ety = _cmd.CreateEntity();
                ety.AddCreateEntity(e.createEntity.configName);
            }
        }
    }
}
