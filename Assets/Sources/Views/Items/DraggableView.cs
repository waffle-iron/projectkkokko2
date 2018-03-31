using UnityEngine;
using System.Collections;
using System.Linq;
using Entitas;
using System;
using UniRx;

public class DraggableView : View
{
    [SerializeField]
    private SpriteRenderer _sprite;

    private bool _drag = false;

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
            if (_service.touch[0].Phase == TouchPhase.Began && _service.touch[0].Hits.Select(raycast => raycast.transform).Contains(this.transform))
            {
                _drag = true;
                //create input entity 
                var inputEty = contexts.input.CreateEntity();
                inputEty.AddTargetEntityID(this.ID);
                inputEty.AddTouchPhase(_service.touch[0].Phase);
            }
            else if (_service.touch[0].Phase == TouchPhase.Ended)
            {
                _drag = false;
                //create input entity
                var inputEty = contexts.input.CreateEntity();
                inputEty.AddTargetEntityID(this.ID);
                inputEty.AddTouchPhase(_service.touch[0].Phase);
            }

            if (_drag)
            {
                var newPos = _service.touch[0].WorldPosition;
                newPos.z = this.transform.position.z;
                this.transform.position = newPos;
            }
        }
    }
}
