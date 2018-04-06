using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using UniRx;

public class ResultsConfig : UnityEntityConfig
{
    //enter serialized fields here
    [Header("Results Dialog Settings")]
    [SerializeField]
    private string _id;
    [SerializeField]
    private string _title;
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
        gameEty.AddDialog(_id, DialogType.MINIGAME_RESULT, _title, "", _isPause);
        if (_okAction != null) { gameEty.AddOkAction(_okAction); }
        if (_cancelAction != null) { gameEty.AddCancelAction(_cancelAction); }

        return gameEty;
    }
}

