using System;
using System.Collections.Generic;
using Entitas;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class ScoreView : View, IScoreListener
{
    [SerializeField]
    private Text _scoreText;

    public void OnScore (GameEntity entity, int value)
    {
        _scoreText.text = value.ToString();
    }

    protected override IObservable<bool> Initialize (IEntity entity, IContext context)
    {
        return Observable.Return(true);
    }

    protected override void RegisterListeners (IEntity entity, IContext context)
    {
        var gameEty = (GameEntity)entity;
        gameEty.AddScoreListener(this);
    }

    protected override void UnregisterListeners (IEntity entity, IContext context)
    {
        var gameEty = (GameEntity)entity;
        gameEty.RemoveScoreListener(this);
    }
}

