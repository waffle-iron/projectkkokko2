
using UnityEngine;
using System.Collections;
using System;

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
        if (Input.GetMouseButtonDown(0))
        {
            _touchData = PollMouseTouch(Input.mousePosition, TouchPhase.Began, _camera);
            if (OnTouch != null) { OnTouch(_touchData); }
        }
        else if (Input.GetMouseButton(0))
        {
            _touchData = PollMouseTouch(Input.mousePosition, Input.mouseScrollDelta.magnitude > 0f ? TouchPhase.Moved : TouchPhase.Stationary, _camera);
            if (OnTouch != null) { OnTouch(_touchData); }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _touchData = PollMouseTouch(Input.mousePosition, TouchPhase.Ended, _camera);
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

    private TouchData[] PollMouseTouch (Vector2 screenPos, TouchPhase phase, Camera camera)
    {
        var newTouches = new TouchData[1];
        var worldPos = (Vector3)screenPos;
        worldPos.z = camera.transform.position.z;
        worldPos = camera.ScreenToWorldPoint(worldPos);

        var results = Physics2D.RaycastAll(worldPos, Vector2.zero, Mathf.Infinity, _layerMask);
        newTouches[0] = new TouchData(1, screenPos, worldPos, phase, results);

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
            var results = Physics2D.RaycastAll(worldPos, Vector2.zero, Mathf.Infinity, _layerMask);
            newTouches[ctr] = new TouchData(touch.fingerId, screenPos, worldPos, touch.phase, results);
        }

        return newTouches;
    }
}
