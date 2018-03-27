﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Entitas;
using DG.Tweening;
using UniRx;
using System;

public class SecondaryNeedView : View, IGameTriggerListener
{
    [SerializeField]
    private RectTransform _image;
    [SerializeField]
    private Image _icon;
    [SerializeField]
    private string imageSprite;
    [SerializeField]
    private NeedType _need;

    private Tween _tweenAnim = null;


    protected override IObservable<bool> Initialize (IEntity entity, IContext context)
    {
        _icon.enabled = false;

        return this.contexts.meta.viewService.instance.GetAsset<Sprite>(imageSprite)
            .Select(result =>
            {
                _icon.sprite = result;
                return true;
            });
    }

    public void OnTrigger (GameEntity entity, DurationType duration, bool state)
    {
        if (entity.hasNeed && _need == entity.need.type)
        {
            if (_tweenAnim != null)
            {
                _tweenAnim.Kill();
            }
            if (state == true)
            {
                Show();
            }
            else
            {
                Hide();
            }
        }
    }

    protected override void RegisterListeners (IEntity entity, IContext context)
    {
        var gameEntity = (GameEntity)entity;
        gameEntity.AddGameTriggerListener(this);
    }

    protected override void UnregisterListeners (IEntity entity, IContext context)
    {
        var gameEntity = (GameEntity)entity;
        gameEntity.RemoveGameTriggerListener(this);
    }


    void Show ()
    {
        _image.GetComponent<Image>().enabled = true;
        _tweenAnim = _image.DOShakeScale(3f).SetLoops(-1).Play();
    }

    void Hide ()
    {
        _image.GetComponent<Image>().enabled = false;
    }
}
