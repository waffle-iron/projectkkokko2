using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;
using System.Linq;

public class WipeReactiveSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _game;

    public WipeReactiveSystem (Contexts contexts) : base(contexts.game)
    {
        _game = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collector
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.TouchData, GameMatcher.Wipe, GameMatcher.TargetTag));
    }

    protected override bool Filter (GameEntity entity)
    {
        // check for required components
        return entity.hasTouchData &&
            entity.touchData.current.Phase == TouchPhase.Moved &&
            entity.hasWipe &&
            entity.hasOnCollision &&
            entity.onCollision.type == CollisionType.STAY &&
            entity.hasTargetTag;
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            var target = _game.GetEntityWithID(e.onCollision.otherID);
            if (target == null || target.hasTag == false || e.targetTag.current.Any(tag => target.tag.current == tag) == false) { continue; }

            var wipeProg = e.hasWipeProgress ? e.wipeProgress.value : 0f;
            wipeProg += e.touchData.current.DeltaWorldPosition.magnitude / e.wipe.deltaAmountToComplete;
            wipeProg = Mathf.Clamp(wipeProg, 0f, 1f);

            e.ReplaceWipeProgress(wipeProg);
        }
    }
}