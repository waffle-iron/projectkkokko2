using System;
using System.Collections.Generic;
using CodeStage.AntiCheat.ObscuredTypes;
using Entitas;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class ShopUIView : View, IGameAffordListener, IGamePriceListener, IGamePurchasedListener, IGamePreviewListener, IGamePreviewRemovedListener
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

    private bool _isPreview = false;

    protected override IObservable<bool> Initialize (IEntity entity, IContext context)
    {
        //init look
        _equipped.enabled = false;
        _purchased.enabled = false;
        _price.text = "";
        _display.color = Color.white;

        var gameety = (GameEntity)entity;
        _price.text = gameety.hasPrice ? gameety.price.amount.ToString() : "0";
        _isPreview = gameety.isPreview;

        if (gameety.hasFood)
        {
            return contexts.meta.viewService.instance.GetAsset<Sprite>(gameety.food.id, sprite => { _display.sprite = sprite; });
        }
        else if (gameety.hasApartmentItem)
        {
            return contexts.meta.viewService.instance.GetAsset<Sprite>(gameety.apartmentItem.data.id, sprite => { _display.sprite = sprite; });
        }

        return Observable.Return(true);
    }

    protected override void RegisterListeners (IEntity entity, IContext context)
    {
        var gameEntity = (GameEntity)entity;
        gameEntity.AddGameAffordListener(this);
        gameEntity.AddGamePriceListener(this);
        gameEntity.AddGamePurchasedListener(this);
        gameEntity.AddGamePreviewListener(this);
        gameEntity.AddGamePreviewRemovedListener(this);

    }

    protected override void UnregisterListeners (IEntity entity, IContext context)
    {
        var gameEntity = (GameEntity)entity;
        gameEntity.RemoveGameAffordListener(this);
        gameEntity.RemoveGamePriceListener(this);
        gameEntity.RemoveGamePurchasedListener(this);
        gameEntity.RemoveGamePreviewListener(this);
        gameEntity.RemoveGamePreviewRemovedListener(this);
    }

    public void OnAfford (GameEntity entity, bool state)
    {
        _display.color = state ? _afford : _cantAfford;
    }

    public void OnPrice (GameEntity entity, ObscuredInt amount)
    {
        _price.text = amount.ToString();
    }

    public void OnPurchased (GameEntity entity)
    {
        _purchased.enabled = true;
    }

    public void OnPreview (GameEntity entity)
    {
        _isPreview = true;
    }

    public void OnPreviewRemoved (GameEntity entity)
    {
        _isPreview = false;
    }

    public void OnClick ()
    {
        if (_isPreview == false)
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

