using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entitas;

public class PauseEntityConfig : UnityEntityConfig
{
    protected override IEntity CustomCreate (Contexts contexts)
    {
        var entity = contexts.game.CreateEntity();
        entity.AddPause(false);
        entity.isDoNotDestroyOnSceneChange = true;
        //compnent pause stauts

        return entity;
    }
}
