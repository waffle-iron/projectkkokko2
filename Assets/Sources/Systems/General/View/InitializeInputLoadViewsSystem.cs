using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class InitializeInputLoadViewsSystem : IInitializeSystem
{
    private IGroup<InputEntity> _loads;
    private CommandContext _cmd;

    public InitializeInputLoadViewsSystem (Contexts contexts)
    {
        _cmd = contexts.command;
        _loads = contexts.input.GetGroup(InputMatcher.LoadViews);
    }

    public void Initialize ()
    {
        foreach (var e in _loads.GetEntities())
        {
            // do stuff to the matched entities
            var cmdEntity = _cmd.CreateEntity();
            cmdEntity.AddLoadViews(e.loadViews.paths, e.loadViews.includeSceneObjects);
        }
    }
}