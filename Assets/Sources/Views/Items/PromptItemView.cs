using System;
using System.Collections.Generic;
using Entitas;
using UniRx;
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

    protected override void OnEnable ()
    {
        base.OnEnable();
    }

    protected override IObservable<bool> Initialize (IEntity entity, IContext context)
    {
        return Observable.Return(true);
    }

    public void OnPrePurchase (GameEntity entity)
    {
        if (entity.hasPrice)
        {
            var itemName = "";

            if (entity.hasAccessory) { itemName = entity.accessory.id; }
            else if (entity.hasFood) { itemName = entity.food.id; }
            else if (entity.hasApartmentItem) { itemName = entity.apartmentItem.data.id; }

            var text = $"are you sure you want to buy {itemName} for {entity.price.amount}?";

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

