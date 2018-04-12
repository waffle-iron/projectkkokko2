
using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class UnityTouchService : MonoBehaviour, IInputTouchService
{
    [SerializeField]
    private Camera _camera;
    [SerializeField]
    private int _layerMask;

    public TouchData[] touch
    {
        get {
            return _touchData;
        }
    }

    public static event Action<TouchData[]> OnTouch;

    private TouchData[] _touchData = null;

#if UNITY_EDITOR
    private Vector3 _prevScreenPos = Vector3.zero;
    private Vector3 _prevWorldPos = Vector3.zero;
#endif

    // Use this for initialization
    void Start ()
    {
        _touchData = null;
        if (_camera == null)
        {
            _camera = Camera.main;
        }
    }

    // Update is called once per frame
    void Update ()
    {
#if UNITY_EDITOR
        if (_prevScreenPos == Vector3.zero) { _prevScreenPos = Input.mousePosition; }
        var currPos = Input.mousePosition;
        var delta = currPos - _prevScreenPos;
        delta.x = Mathf.Abs(delta.x);
        delta.y = Mathf.Abs(delta.y);
        _prevScreenPos = currPos;

        if (Input.GetMouseButtonDown(0))
        {
            _touchData = PollMouseTouch(currPos, delta, TouchPhase.Began, _camera);
            if (OnTouch != null) { OnTouch(_touchData); }
        }
        else if (Input.GetMouseButton(0))
        {
            _touchData = PollMouseTouch(currPos, delta, delta.magnitude > 0f ? TouchPhase.Moved : TouchPhase.Stationary, _camera);
            //Debug.Log(_touchData[0].Phase);
            if (OnTouch != null) { OnTouch(_touchData); }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _touchData = PollMouseTouch(currPos, delta, TouchPhase.Ended, _camera);
            if (OnTouch != null) { OnTouch(_touchData); }
        }

#elif UNITY_ANDROID || UNITY_IOS
        if (Input.touchCount > 0)
        {
            _touchData = PollScreenTouch(Input.touchCount);

            if (OnTouch != null) { OnTouch(_touchData); }
        }
#endif
        else
        {
            _touchData = null;
        }

    }

    private TouchData[] PollMouseTouch (Vector2 screenPos, Vector2 screenDelta, TouchPhase phase, Camera camera)
    {
        var newTouches = new TouchData[1];
        var worldPos = (Vector3)screenPos;
        worldPos.z = camera.transform.position.z;
        worldPos = camera.ScreenToWorldPoint(worldPos);
        if (_prevWorldPos == Vector3.zero) { _prevWorldPos = worldPos; }
        var deltaWorldPos = worldPos - _prevWorldPos;
        deltaWorldPos.x = Mathf.Abs(deltaWorldPos.x);
        deltaWorldPos.y = Mathf.Abs(deltaWorldPos.y);
        deltaWorldPos.z = Mathf.Abs(deltaWorldPos.z);
        _prevWorldPos = worldPos;

        var results = Physics2D.RaycastAll(worldPos, Vector2.zero, Mathf.Infinity, _layerMask);
        newTouches[0] = new TouchData(1, screenPos, worldPos, screenDelta, deltaWorldPos, phase, Time.time, results);

        return newTouches;
    }

    private TouchData[] PollScreenTouch (int touchCount, Camera camera)
    {
        var newTouches = new TouchData[touchCount];
        for (int ctr = 0; ctr < touchCount; ctr++)
        {
            var touch = Input.GetTouch(ctr);
            var screenPos = touch.position;
            var worldPos = (Vector3)screenPos;
            worldPos.z = camera.transform.position.z;
            worldPos = camera.ScreenToWorldPoint(worldPos);
            if (_prevWorldPos == Vector3.zero) { _prevWorldPos = worldPos; }
            var deltaWorldPos = worldPos - _prevWorldPos;
            deltaWorldPos.x = Mathf.Abs(deltaWorldPos.x);
            deltaWorldPos.y = Mathf.Abs(deltaWorldPos.y);
            deltaWorldPos.z = Mathf.Abs(deltaWorldPos.z);
            _prevWorldPos = worldPos;

            var results = Physics2D.RaycastAll(worldPos, Vector2.zero, Mathf.Infinity, _layerMask);
            newTouches[ctr] = new TouchData(touch.fingerId, screenPos, worldPos, touch.deltaPosition, deltaWorldPos, touch.phase, Time.time, results);
        }

        return newTouches;
    }
}
