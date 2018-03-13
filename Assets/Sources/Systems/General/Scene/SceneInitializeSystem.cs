using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class SceneInitializeSystem : IInitializeSystem
{
    private readonly MetaContext _meta;

    public SceneInitializeSystem (Contexts contexts)
    {
        _meta = contexts.meta;
    }

    public void Initialize ()
    {
        // Initialization code here
        IEntity entity;
        _meta.entityService.instance.Get(EntityCfgID.SCENE_GAME, out entity);
    }
}