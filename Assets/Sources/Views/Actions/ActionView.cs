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
    private UnityEntityConfig _inputAction;

    protected override void OnEnable ()
    {
        base.OnEnable();
        _text.text = label;
    }

    protected override void RegisterListeners (IEntity entity, IContext context)
    {
        //var gameEntity = (GameEntity)entity;
        
    }

    protected override void UnregisterListeners (IEntity entity, IContext context)
    {
        
    }

    public void OnExecute ()
    {
        _inputAction.Create(Contexts.sharedInstance);
    }
}

