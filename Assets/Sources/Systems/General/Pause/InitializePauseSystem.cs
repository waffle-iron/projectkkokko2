using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class InitializePauseSystem : IInitializeSystem
{
    private readonly MetaContext _meta;

    public InitializePauseSystem (Contexts contexts)
    {
        _meta = contexts.meta;
    }

    public void Initialize ()
    {
        IEntity entity;
        if (_meta.entityService.instance.Get(EntityCfgID.PAUSE, out entity))
        {
            //do something when not found
        }
    }
}