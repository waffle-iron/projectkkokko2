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
    [SerializeField]
    private bool _isOnTopOnly = false;

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
            bool result = false;

            if (_service.touch[0].Hits.Length > 0)
            {
                result = _isOnTopOnly ?
                _service.touch[0].Hits[0].transform == this.transform :
                _service.touch[0].Hits.Select(raycast => raycast.transform).Contains(this.transform);
            }


            if ((_service.touch[0].Phase == TouchPhase.Began ||
                _service.touch[0].Phase == TouchPhase.Moved ||
                _service.touch[0].Phase == TouchPhase.Stationary) &&
                result)
            {
                _drag = true;
                //create input entity 
                var inputEty = contexts.input.CreateEntity();
                inputEty.AddTargetEntityID(this.ID);
                inputEty.AddTouchData(_service.touch[0]);
            }
            else if (_service.touch[0].Phase == TouchPhase.Ended)
            {
                _drag = false;
                //create input entity
                var inputEty = contexts.input.CreateEntity();
                inputEty.AddTargetEntityID(this.ID);
                inputEty.AddTouchData(_service.touch[0]);
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
