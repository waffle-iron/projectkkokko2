using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;
using Entitas;
using System.Linq;

public class ReloadEquippedItemsReactiveSystem : ReactiveSystem<GameEntity>
{
    private readonly MetaContext _meta;
    private readonly GameContext _game;
    private readonly InputContext _input;
    private readonly IGroup<GameEntity> _accessories;

    public ReloadEquippedItemsReactiveSystem (Contexts contexts) : base(contexts.game)
    {
        _meta = contexts.meta;
        _game = contexts.game;
        _input = contexts.input;
        _accessories = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Accessory, GameMatcher.SaveID));
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collector
        return context.CreateCollector(GameMatcher.AnyOf(GameMatcher.LoadSceneComplete, GameMatcher.LoadedViewsComplete, GameMatcher.LoadEntitiesComplete));
    }

    protected override bool Filter (GameEntity entity)
    {
        // check for required components
        return
            _game.isLoadedViewsComplete &&
            _game.isLoadSceneComplete &&
            _game.isLoadEntitiesComplete &&
            _game.hasEquippedItems &&
            _game.equippedItems._filterInScenes.Contains(SceneManager.GetActiveScene().name);
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            if (_game.hasEquippedItems)
            {
                var equips = _game.equippedItems._accessoryList;

                foreach (var acc in _accessories.GetEntities())
                {
                    if (equips.Contains(acc.saveID.value) == false)
                    {
                        acc.isToDestroy = true;
                    }
                }
            }
        }
    }
}