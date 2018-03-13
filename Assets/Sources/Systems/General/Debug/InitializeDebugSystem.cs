using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class InitializeDebugSystem : IInitializeSystem
{
    private readonly MetaContext _meta;

    public InitializeDebugSystem(Contexts contexts)
    {
        _meta = contexts.meta;
    }

    public void Initialize()
    {
        // Initialization code here
        IEntity entity;
        _meta.entityService.instance.Get(EntityCfgID.DEBUG_GAME, out entity);
    }
}