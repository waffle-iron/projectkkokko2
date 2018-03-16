using System;
using System.Collections.Generic;
using CodeStage.AntiCheat.ObscuredTypes;
using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class AccessoryUIView : View, IGameAffordListener, IGameEquippedListener, IGameEquippedRemovedListener, IGamePreviewListener, IGamePreviewRemovedListener, IGamePriceListener
{
    [Header("Item Specific")]
    [SerializeField]
    private Sprite _display;

    [Header("Required")]
    [SerializeField]
    private Image _afford;
    [SerializeField]
    private Image _cantAfford;
    [SerializeField]
    private Image _equipped;
    [SerializeField]
    private Text _text;

    protected override void RegisterListeners (IEntity entity, IContext context)
    {
        var gameEntity = (GameEntity)entity;
        gameEntity.AddGameAffordListener(this);
        gameEntity.AddGameEquippedListener(this);
        gameEntity.AddGameEquippedRemovedListener(this);
        gameEntity.AddGamePreviewListener(this);
        gameEntity.AddGamePreviewRemovedListener(this);
        gameEntity.AddGamePriceListener(this);
    }

    protected override void UnregisterListeners (IEntity entity, IContext context)
    {
        var gameEntity = (GameEntity)entity;
        gameEntity.RemoveGameAffordListener(this);
        gameEntity.RemoveGameEquippedListener(this);
        gameEntity.RemoveGameEquippedRemovedListener(this);
        gameEntity.RemoveGamePreviewListener(this);
        gameEntity.RemoveGamePreviewRemovedListener(this);
        gameEntity.RemoveGamePriceListener(this);
    }

    public void OnAfford (GameEntity entity, bool state)
    {
        _afford.enabled = state;
        _cantAfford.enabled = !state;
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
        _text.text = amount.ToString();
    }

    public void OnPreview (GameEntity entity)
    {
    }

    public void OnPreviewRemoved (GameEntity entity)
    {
    }

}

