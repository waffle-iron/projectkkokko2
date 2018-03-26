using System;
using System.Collections.Generic;
using CodeStage.AntiCheat.ObscuredTypes;
using Entitas;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class AccessoryUIView : View, IGameAffordListener, IGameEquippedListener, IGameEquippedRemovedListener, IGamePriceListener, IGamePurchasedListener, IGameAccessoryListener
{
    [Header("Item Specific")]
    [SerializeField]
    private Image _display;

    [Header("Required")]
    [SerializeField]
    private Color _afford;
    [SerializeField]
    private Color _cantAfford;
    [SerializeField]
    private Image _equipped;
    [SerializeField]
    private Image _purchased;
    [SerializeField]
    private Text _price;

    protected override void OnEnable ()
    {
        base.OnEnable();
        //init look
        _equipped.enabled = false;
        _purchased.enabled = false;
        _price.text = "";
        _display.color = Color.white;
    }

    protected override IObservable<bool> Initialize ()
    {
        return Observable.Return(true);
    }

    protected override void RegisterListeners (IEntity entity, IContext context)
    {
        var gameEntity = (GameEntity)entity;
        gameEntity.AddGameAffordListener(this);
        gameEntity.AddGameEquippedListener(this);
        gameEntity.AddGameEquippedRemovedListener(this);
        gameEntity.AddGamePriceListener(this);
        gameEntity.AddGamePurchasedListener(this);
        gameEntity.AddGameAccessoryListener(this);

    }

    protected override void UnregisterListeners (IEntity entity, IContext context)
    {
        var gameEntity = (GameEntity)entity;
        gameEntity.RemoveGameAffordListener(this);
        gameEntity.RemoveGameEquippedListener(this);
        gameEntity.RemoveGameEquippedRemovedListener(this);
        gameEntity.RemoveGamePriceListener(this);
        gameEntity.RemoveGamePurchasedListener(this);
        gameEntity.RemoveGameAccessoryListener(this);
    }

    public void OnAfford (GameEntity entity, bool state)
    {
        _display.color = state ? _afford : _cantAfford;
    }

    public void OnEquipped (GameEntity entity)
    {
        _equipped.enabled = true;
    }

    public void OnEquippedRemoved (GameEntity entity)
    {
        _equipped.enabled = false;
    }

    public void OnPrice (GameEntity entity, ObscuredInt amount)
    {
        _price.text = amount.ToString();
    }

    public void OnPurchased (GameEntity entity)
    {
        _purchased.enabled = true;
    }

    public void OnAccessory (GameEntity entity, AccessoryID id, AccessoryType type)
    {
        _display.sprite = Resources.Load<Sprite>(Enum.GetName(typeof(AccessoryID), id));
    }

    public void OnClick ()
    {
        var gameEntity = (GameEntity)this.EntityLink.entity;
        if (gameEntity.isPreview == false)
        {
            var inputEntity = contexts.input.CreateEntity();
            inputEntity.AddTargetEntityID(((IIDEntity)EntityLink.entity).iD.value);
            inputEntity.isPreview = true;
        }
        else
        {
            var inputEntity = contexts.input.CreateEntity();
            inputEntity.AddTargetEntityID(((IIDEntity)EntityLink.entity).iD.value);
            inputEntity.isPurchased = true;
        }
    }
}

