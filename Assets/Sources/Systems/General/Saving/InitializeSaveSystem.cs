using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class InitializeSaveSystem : IInitializeSystem
{
    private readonly MetaContext _meta;

    public InitializeSaveSystem (Contexts contexts)
    {
        _meta = contexts.meta;
    }

    public void Initialize ()
    {
        // Initialization code here
        IEntity save;
        IEntity load;
        _meta.entityService.instance.Get(EntityCfgID.SAVE, out save);
        _meta.entityService.instance.Get(EntityCfgID.LOAD, out load);
    }
}