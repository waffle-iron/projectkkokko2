using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class PromptItemView : View, IGamePrePurchaseListener
{
    [Tag, SerializeField]
    private string _targetPrompt;

    private IPrompt _prompt;

    protected override void Awake ()
    {
        base.Awake();
        _prompt = GameObject.FindGameObjectWithTag(_targetPrompt).GetComponent<IPrompt>();
    }

    public void OnPrePurchase (GameEntity entity)
    {
        if (entity.hasAccessory && entity.hasPrice)
        {
            var text = $"are you sure you want to buy {entity.accessory.id} for {entity.price.amount}?";

            Action yesAction = () =>
            {
                var input = this.contexts.input.CreateEntity();
                input.AddTargetEntityID(((IIDEntity)this.EntityLink.entity).iD.value);
                input.isPurchased = true;
            };

            Action noAction = () =>
            {
                var input = this.contexts.input.CreateEntity();
                input.AddTargetEntityID(((IIDEntity)this.EntityLink.entity).iD.value);
                input.isCancel = true;
            };

            _prompt.Activate(yesAction, noAction, text);
        }
    }

    protected override void RegisterListeners (IEntity entity, IContext context)
    {
        var gameEntity = (GameEntity)entity;
        gameEntity.AddGamePrePurchaseListener(this);
    }

    protected override void UnregisterListeners (IEntity entity, IContext context)
    {
        var gameEntity = (GameEntity)entity;
        gameEntity.RemoveGamePrePurchaseListener(this);
    }


}

