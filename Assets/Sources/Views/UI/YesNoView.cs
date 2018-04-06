using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Entitas;
using UniRx;

public class YesNoView : View, IGameActiveDialogListener, IGameActiveDialogRemovedListener
{
    //insert serialized fields here
    [SerializeField]
    private Text _title;
    [SerializeField]
    private Text _message;

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
        if (entity.hasDialog && entity.dialog.type == DialogType.YES_NO)
        {
            var dialog = entity.dialog;
            _title.text = dialog.title;
            _message.text = dialog.message;

            if (entity.hasOkAction)
            {
                _ok = new Action(() =>
                {
                    if (entity != null)
                    {
                        entity.okAction.action.Execute(entity, contexts);
                    }
                });
            }

            if (entity.hasCancelAction)
            {
                _cancel = new Action(() =>
                {
                    if (entity != null)
                    {
                        entity.cancelAction.action.Execute(entity, contexts);
                    }
                });
            }
        }

        this.gameObject.SetActive(true);
    }

    public void OnActiveDialogRemoved (GameEntity entity)
    {
        this.gameObject.SetActive(false);
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
    }

    protected override void UnregisterListeners (IEntity entity, IContext context)
    {
        var gameety = (GameEntity)entity;
        gameety.RemoveGameActiveDialogListener(this);
        gameety.RemoveGameActiveDialogRemovedListener(this);
    }
}

