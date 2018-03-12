using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class NeedInitializeSystem : IInitializeSystem
{
    private readonly MetaContext _meta;

    public NeedInitializeSystem (Contexts contexts)
    {
        _meta = contexts.meta;
    }

    public void Initialize ()
    {
        // Initialization code here
        var service = _meta.entityService.instance;

        IEntity hungerEntity;

        service.Get(EntityCfgID.HUNGER, out hungerEntity);
    }
}