using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entitas;

public class SceneConfig : UnityEntityConfig
{
    protected override IEntity CustomCreate (Contexts contexts)
    {
        var entity = contexts.game.CreateEntity();
        entity.isDoNotDestroyOnSceneChange = true;
        return entity;
    }
}

