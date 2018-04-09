using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class TouchdataInputReactiveSystem : ReactiveSystem<InputEntity>
{
    private readonly GameContext _game;
    private readonly InputContext _input;
    private readonly CommandContext _cmd;

    public TouchdataInputReactiveSystem (Contexts contexts) : base(contexts.input)
    {
        _input = contexts.input;
        _game = contexts.game;
        _cmd = contexts.command;
    }

    protected override ICollector<InputEntity> GetTrigger (IContext<InputEntity> context)
    {
        //return collector
        return context.CreateCollector(InputMatcher.AllOf(InputMatcher.TargetEntityID, InputMatcher.TouchData));
    }

    protected override bool Filter (InputEntity entity)
    {
        // check for required components
        return entity.hasTouchData && entity.hasTargetEntityID;
    }

    protected override void Execute (List<InputEntity> entities)
    {
        foreach (var e in entities)
        {
            // do stuff to the matched entities
            var target = _game.GetEntityWithID(e.targetEntityID.value);

            if (target != null)
            {
                //skip if beyond touch time gap
                if (target.hasTouchTimeGap &&
                    target.hasTouchData && 
                    target.touchData.current.Phase == TouchPhase.Began &&
                    e.touchData.current.Phase == TouchPhase.Ended &&
                    (e.touchData.current.TouchTime - target.touchData.current.TouchTime) > target.touchTimeGap.value) { continue; }

                var cmdEty = _cmd.CreateEntity();
                cmdEty.AddTargetEntityID(e.targetEntityID.value);
                //Debug.Log(e.touchData.current.Phase);
                cmdEty.AddTouchData(e.touchData.current);
            }
        }
    }
}