using UnityEngine;
using System.Collections;
using UniRx;
using Entitas;
using System;
using System.Linq;

public class TouchableView : View
{
    private bool _touch = false;

    private IInputTouchService _service;

    protected override IObservable<bool> Initialize (IEntity entity, IContext context)
    {
        _service = Contexts.sharedInstance.meta.touchService.instance;
        if (_service == null)
        {
            Debug.LogError("touch service is null");
        }

        return Observable.Return(true);
    }

    protected override void RegisterListeners (IEntity entity, IContext context)
    {
        var gameEty = (GameEntity)entity;
    }

    protected override void UnregisterListeners (IEntity entity, IContext context)
    {
        var gameEty = (GameEntity)entity;
    }

    protected override void Update ()
    {
        if (_service != null && _service.touch != null)
        {
            if ((_service.touch[0].Phase == TouchPhase.Began ||
                _service.touch[0].Phase == TouchPhase.Moved ||
                _service.touch[0].Phase == TouchPhase.Stationary) &&
                _service.touch[0].Hits.Select(raycast => raycast.transform).Contains(this.transform))
            {
                _touch = true;
                //create input entity 
                var inputEty = contexts.input.CreateEntity();
                inputEty.AddTargetEntityID(this.ID);
                inputEty.AddTouchData(_service.touch[0]);
                Debug.Log(_service.touch[0].Phase);
            }
            else if (_service.touch[0].Phase == TouchPhase.Ended ||
                _service.touch[0].Phase == TouchPhase.Canceled &&
                _touch == true)
            {
                _touch = false;
                //create input entity
                var inputEty = contexts.input.CreateEntity();
                inputEty.AddTargetEntityID(this.ID);
                inputEty.AddTouchData(_service.touch[0]);
            }
        }
    }
}
