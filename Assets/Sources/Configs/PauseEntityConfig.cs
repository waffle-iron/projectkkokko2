﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entitas;

public class PauseEntityConfig : UnityEntityConfig
{
    protected override IEntity CustomCreate ()
    {
        var entity = Contexts.sharedInstance.game.CreateEntity();
        entity.AddPause(false);
        entity.isDoNotDestroyOnSceneChange = true;

        return entity;
    }
}
