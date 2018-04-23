using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UniRx;
using System;
using Entitas;

public class SpawnItemOnDrag : MonoBehaviour
{
    [SerializeField]
    private string _entityID;

    [SerializeField]
    private RectTransform _container;
    [SerializeField]
    private Camera _camera;
    [SerializeField]
    private RectTransform _item;

    Vector3 _originalPos;
    float _originalzPos;
    Mask _mask;

    private bool? _drag = null;
    private bool _isSpawned = false;

    void OnEnable ()
    {
        _originalPos = _item.anchoredPosition;
        _originalzPos = _item.position.z;
        _mask = _container.GetComponentInChildren<Mask>();
    }

    public void OnBeginDrag (PointerEventData eventData)
    {
        if (_drag == null)
        {
            if (eventData.delta.normalized.y > 0.8f) { _drag = true; }
            else { _drag = false; }
        }
    }


    public void OnDrag (PointerEventData eventData)
    {
        if (_drag == true)
        {
            ToggleMask(false);
            var newPos = (Vector3)eventData.position;
            newPos.z = _originalzPos;
            newPos = _camera.ScreenToWorldPoint(newPos);
            _item.position = newPos;

            if (_isSpawned == false && RectTransformUtility.RectangleContainsScreenPoint(_container, eventData.position, _camera) == false)
            {
                IEntity entity;
                Contexts.sharedInstance.meta.entityService.instance.Get(_entityID, out entity);
                var inputety = Contexts.sharedInstance.input.CreateEntity();
                inputety.AddTargetEntityID(((IIDEntity)entity).iD.value);
                inputety.AddPosition(newPos);
                inputety.isTeleport = true;
                _isSpawned = true;
                OnEndDrag(eventData);
            }
        }

    }

    public void OnEndDrag (PointerEventData eventData)
    {
        if (_drag == true)
        {
            _item.anchoredPosition = _originalPos;

            ToggleMask(true);
        }

        _drag = null;
        _isSpawned = false;
    }

    void ToggleMask (bool state)
    {
        if (_mask != null && _mask.enabled != state)
        {
            _mask.enabled = state;
        }
    }
}
