using System;
using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class ActionView : View
{
    [SerializeField]
    private Text _text;
    [SerializeField]
    private string label;
    [SerializeField]
    private EntityCfgID _inputAction;

    protected override void OnEnable ()
    {
        base.OnEnable();
        _text.text = label;
    }

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

