using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class WipeCompleteReactiveSystem : ReactiveSystem<GameEntity>
{
    private readonly MetaContext _meta;

    private const string HYGIENE_ACTION_ENTITY = "ACTION_BATH_INPUT";

    public WipeCompleteReactiveSystem (Contexts contexts) : base(contexts.game)
    {
        _meta = contexts.meta;
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collector
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.WipeProgress, GameMatcher.Soap));
    }

    protected override bool Filter (GameEntity entity)
    {
        // check for required components
        return entity.hasWipeProgress &&
            entity.wipeProgress.value == 1.0f &&
            entity.hasSoap;
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            // do stuff to the matched entities
            IEntity hygieneReset;
            _meta.entityService.instance.Get(HYGIENE_ACTION_ENTITY, out hygieneReset);

            ((INeedRecoveryModifierEntity)hygieneReset).AddNeedRecoveryModifier(e.soap.recovery);

            e.isToDestroy = true;
        }
    }
}