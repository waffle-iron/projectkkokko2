using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class InputLoadSceneCompleteSystem : ReactiveSystem<InputEntity>
{
    private readonly CommandContext _command;

    public InputLoadSceneCompleteSystem (Contexts contexts) : base(contexts.input)
    {
        _command = contexts.command;
    }

    protected override ICollector<InputEntity> GetTrigger (IContext<InputEntity> context)
    {
        //return collector
        return context.CreateCollector(InputMatcher.LoadSceneComplete);
    }

    protected override bool Filter (InputEntity entity)
    {
        // check for required components
        return entity.isLoadSceneComplete;
    }

    protected override void Execute (List<InputEntity> entities)
    {
        foreach (var e in entities)
        {
            // do stuff to the matched entities
            if (_command.isLoadSceneComplete == false)
            {
                _command.isLoadSceneComplete = true;
            }
        }
    }
}