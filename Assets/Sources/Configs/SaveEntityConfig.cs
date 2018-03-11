using System;
using System.Collections.Generic;
using System.Linq;
using Entitas;

class SaveEntityConfig : UnityEntityConfig
{
    protected override IEntity CustomCreate (Contexts contexts)
    {
        var entity = contexts.game.CreateEntity();
        entity.isDoNotDestroyOnSceneChange = true;
        return entity;
    }
}

