using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class ActionInitializeSystem : IInitializeSystem
{
    private readonly GameContext _game;
    private readonly MetaContext _meta;

    public ActionInitializeSystem (Contexts contexts)
    {
        _game = contexts.game;
        _meta = contexts.meta;
    }

    public void Initialize ()
    {
        // Initialization code here
        var service = _meta.entityService.instance;
        IEntity eat, poop, exercise, bath, lights, job, shop;

        service.Get(EntityCfgID.GAME_EAT, out eat);
    }
}