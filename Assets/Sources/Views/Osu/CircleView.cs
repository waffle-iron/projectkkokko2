using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Entitas;
using UniRx;
using DG.Tweening;

public class CircleView : View, ICurrentRangeListener
{
    //insert serialized fields here
    [SerializeField]
    private RectTransform _outerCircle;
    [SerializeField]
    private RectTransform _safeCircle;
    [SerializeField]
    private RectTransform _innerCircle;

    [SerializeField]
    private float _innerSize = 100f;
    [SerializeField]
    private float _outerSize = 300f;

    private float initDistance = 0f;

    [SerializeField]
    private AnimationCurve _curve;

    protected override void Awake ()
    {
        base.Start();
        initDistance = _outerSize - _innerSize;
    }

    public void OnTap ()
    {
        //create input entity 
        var inputEty = contexts.input.CreateEntity();
        inputEty.AddTargetEntityID(this.ID);
        inputEty.AddTouchData(new TouchData(0, Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero, TouchPhase.Began,-1f, null));
    }

    public void OnCurrentRange (GameEntity entity, float value)
    {
        var animValue = Mathf.Lerp(0f, 1f, _curve.Evaluate(value));
        var currDist = (initDistance * animValue) + _innerSize;
        ResizeXY(_outerCircle, new Vector2(currDist, currDist));
    }

    protected override IObservable<bool> Initialize (IEntity entity, IContext context)
    {
        var gameety = (GameEntity)entity;

        ResizeXY(_outerCircle, new Vector2(_outerSize, _outerSize));
        ResizeXY(_innerCircle, new Vector2(_innerSize, _innerSize));

        if (gameety.hasAcceptableRange)
        {
            var newSafeSize = (initDistance * gameety.acceptableRange.value) + _innerCircle.sizeDelta.x;
            ResizeXY(_safeCircle, new Vector2(newSafeSize, newSafeSize));
        }

        return Observable.Return(true);
    }

    protected override void RegisterListeners (IEntity entity, IContext context)
    {
        var gameety = (GameEntity)entity;
        gameety.AddCurrentRangeListener(this);
    }

    protected override void UnregisterListeners (IEntity entity, IContext context)
    {
        var gameety = (GameEntity)entity;
        gameety.RemoveCurrentRangeListener(this);
    }

    void ResizeXY (RectTransform image, Vector2 value)
    {
        image.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, value.x);
        image.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, value.y);
    }

    
}

