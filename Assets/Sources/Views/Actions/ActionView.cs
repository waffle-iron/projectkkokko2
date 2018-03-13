using System;
using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine;

public class ActionView : View
{
    [SerializeField]
    EntityCfgID _inputAction;

    protected override void RegisterListeners (IEntity entity, IContext context)
    {
        //var gameEntity = (GameEntity)entity;
        
    }

    public void OnExecute ()
    {
        IEntity action;
        this.contexts.meta.entityService.instance.Get(_inputAction, out action);
    }
}

