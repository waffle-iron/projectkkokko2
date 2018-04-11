using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine;
using Entitas;

public class ReturnReactiveSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _game;
    private readonly MetaContext _meta;
    private const string RETURN_ENTITY = "FOOD_RETURN_GAME";
    private readonly IGroup<GameEntity> _returners;

    public ReturnReactiveSystem (Contexts contexts) : base(contexts.game)
    {
        _game = contexts.game;
        _meta = contexts.meta;
        _returners = _game.GetGroup(GameMatcher.AllOf(GameMatcher.Returnable));
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collector
        return context.CreateCollector(GameMatcher.Returnable.AddedOrRemoved());
    }

    protected override bool Filter (GameEntity entity)
    {
        // check for required components
        return true;
    }

    protected override void Execute (List<GameEntity> entities)
    {
        if (_returners.count == 0 && _game.isReturn)
        {
            _game.returnEntity.isToDestroy = true;
        }
        else if (_game.isReturn == false && _returners.count > 0)
        {
            _meta.entityService.instance.Get(RETURN_ENTITY);
        }
    }
}