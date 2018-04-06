using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Entitas;
using UniRx;

public class ResultsView : View, IGameActiveDialogListener, IGameActiveDialogRemovedListener, IScoreListener, ITopScoreListener
{
    //insert serialized fields here
    [SerializeField]
    private Text _title;
    [SerializeField]
    private Text _currScore;
    [SerializeField]
    private Text _topScore;
    [SerializeField, Tag]
    private string _scoreTargetTag;

    private Action _ok = null;
    private Action _cancel = null;

    public void Ok ()
    {
        if (_ok != null) { _ok.Invoke(); _ok = null; }
    }

    public void Cancel ()
    {
        if (_cancel != null) { _cancel.Invoke(); _cancel = null; }
    }

    public void OnActiveDialog (GameEntity entity, string id)
    {
        if (entity.hasDialog)
        {
            _title.text = entity.dialog.title;
        }

        var gameEty = (GameEntity)entity;
        if (gameEty.hasOkAction)
        {
            _ok = new Action(() =>
            {
                if (gameEty != null)
                {
                    gameEty.okAction.action.Execute(entity, contexts);
                }
            });
        }

        if (gameEty.hasCancelAction)
        {
            _cancel = new Action(() =>
            {
                if (gameEty != null)
                {
                    gameEty.cancelAction.action.Execute(entity, contexts);
                }
            });
        }

        this.gameObject.SetActive(true);
    }

    public void OnActiveDialogRemoved (GameEntity entity)
    {
        this.gameObject.SetActive(false);
    }

    public void OnScore (GameEntity entity, int value)
    {
        _currScore.text = "Score: " + value.ToString();
    }

    public void OnTopScore (GameEntity entity, int value)
    {
        _topScore.text = "Top Score: " + value.ToString();
    }

    protected override IObservable<bool> Initialize (IEntity entity, IContext context)
    {
        this.gameObject.SetActive(false);

        return Observable.Return(true);
    }

    protected override void RegisterListeners (IEntity entity, IContext context)
    {
        var gameety = (GameEntity)entity;
        gameety.AddGameActiveDialogListener(this);
        gameety.AddGameActiveDialogRemovedListener(this);

        //add top score listener
        var score = contexts.game.GetEntitiesWithTag(_scoreTargetTag).SingleEntity();
        if (score.hasScore && score.hasTopScore)
        {
            score.AddScoreListener(this);
            score.AddTopScoreListener(this);
        }
    }

    protected override void UnregisterListeners (IEntity entity, IContext context)
    {
        var gameety = (GameEntity)entity;
        gameety.RemoveGameActiveDialogListener(this);
        gameety.RemoveGameActiveDialogRemovedListener(this);

        //remove top score listener
        var score = contexts.game.GetEntitiesWithTag(_scoreTargetTag).SingleEntity();
        if (score.hasScore && score.hasTopScore)
        {
            score.RemoveScoreListener(this);
            score.RemoveTopScoreListener(this);
        }
    }
}

