using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class AffordReactiveSystem : IExecuteSystem
{
    private readonly GameContext _game;
    private readonly IGroup<GameEntity> _items;
    private List<GameEntity> _buffer;

    public AffordReactiveSystem (Contexts contexts)
    {
        _game = contexts.game;
        _items = _game.GetGroup(GameMatcher.Price);

        _buffer = new List<GameEntity>();

    }

    public void Execute ()
    {

        foreach (var item in _items.GetEntities(_buffer))
        {
            if (item.isPurchased)
            {
                if (item.hasAfford) { item.RemoveAfford(); }
                continue;
            }

            if (item.hasAfford == false)
            {
                item.AddAfford(false);
            }

            if (item.price.amount <= _game.walletEntity.wallet.amount && item.afford.state == false)
            {
                item.ReplaceAfford(true);
            }

            else if (item.price.amount > _game.walletEntity.wallet.amount && item.afford.state == true)
            {
                item.ReplaceAfford(false);
            }
        }

    }
}