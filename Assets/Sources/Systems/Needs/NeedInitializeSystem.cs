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
        //add other needs here
        IEntity hunger;
        IEntity health;
        
        service.Get(EntityCfgID.HUNGER, out hunger);
        service.Get(EntityCfgID.HEALTH, out health);
    }
}