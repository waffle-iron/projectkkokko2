using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Entitas;

public class ScrollRectDragController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private SpawnItemOnDrag[] _items;
    private ScrollRect _scroll;

    private bool? isScroll = null;

    private SpawnItemOnDrag _active = null;

    public void OnBeginDrag (PointerEventData eventData)
    {
        if (_active == null)
        {
            if (eventData.delta.normalized.y > 0.8f)
            {
                //select the child to update
                _active = eventData.pointerPressRaycast.gameObject.GetComponentInParent<SpawnItemOnDrag>();
                if (_active) { _active.OnBeginDrag(eventData); }
                _scroll.horizontal = false;
            }
        }
    }

    public void OnDrag (PointerEventData eventData)
    {
        if (_active) { _active.OnDrag(eventData); }
    }

    public void OnEndDrag (PointerEventData eventData)
    {
        if (_active) { _active.OnEndDrag(eventData); }
        isScroll = null;
        _active = null;
        _scroll.horizontal = true;
    }

    private void OnEnable ()
    {
        _items = GetComponentsInChildren<SpawnItemOnDrag>();
        _scroll = GetComponentInChildren<ScrollRect>();
    }



}