using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using UniRx;

public class YesNoConfig : UnityEntityConfig
{
    //enter serialized fields here
    [Header("Yes/No Dialog Settings")]
    [SerializeField]
    private string _id;
    [SerializeField]
    private string _title;
    [SerializeField]
    private string _message;
    [SerializeField]
    private bool _isPause;
    [Header("Ok Action")]
    [SerializeField]
    private UIAction _okAction = null;
    [Header("Cancel Action")]
    [SerializeField]
    private UIAction _cancelAction = null;

    protected override IEntity CustomCreate (Contexts contexts)
    {
        var gameEty = contexts.game.CreateEntity();

        gameEty.AddDialog(_id, DialogType.YES_NO, _title, _message, _isPause);
        if (_okAction != null) { gameEty.AddOkAction(_okAction); }
        if (_cancelAction != null) { gameEty.AddCancelAction(_cancelAction); }

        return gameEty;
    }
}

