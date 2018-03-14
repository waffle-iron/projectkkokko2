using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class ItemInitializeSystem : IInitializeSystem
{
    private readonly GameContext _game;
    private readonly MetaContext _meta;

    public ItemInitializeSystem (Contexts contexts)
    {
        _game = contexts.game;
        _meta = contexts.meta;
    }

    public void Initialize ()
    {
        _meta.entityService.instance.Get(EntityCfgID.WALLET_GAME);
        _meta.entityService.instance.Get(EntityCfgID.EQUIPPEDITEMS_GAME);
    }
}