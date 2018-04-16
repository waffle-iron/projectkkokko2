using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class PoopTriggeredReactiveSystem : ReactiveSystem<GameEntity>
{
    private readonly InputContext _input;
    private readonly MetaContext _meta;
    private const string POOP_ENTITY = "PoopEntityConfig";
    private const string POOP_ACTION = "ACTION_POOP_INPUT";

    public PoopTriggeredReactiveSystem (Contexts contexts) : base(contexts.game)
    {
        _input = contexts.input;
        _meta = contexts.meta;
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collector
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Need, GameMatcher.Trigger));
    }

    protected override bool Filter (GameEntity entity)
    {
        // check for required components
        return entity.hasNeed &&
            entity.need.type == NeedType.BLADDER &&
            entity.hasTrigger &&
            entity.trigger.state == true &&
            entity.hasTargetNeed &&
            entity.hasTimer;
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            //create poop
            IEntity poop;
            var poopCount = (uint)Mathf.FloorToInt((e.timer.current / e.trigger.duration.GetInSeconds())) + 1;

            for (int ctr = 0; ctr < poopCount; ctr++)
            {
                _meta.entityService.instance.Get(POOP_ENTITY, out poop);

                var inputStartTimer = _input.CreateEntity();
                inputStartTimer.AddTargetEntityID(((IIDEntity)poop).iD.value);
                inputStartTimer.AddTimerState(true);
            }

            //reset bladder
            _meta.entityService.instance.Get(POOP_ACTION);
        }
    }
}