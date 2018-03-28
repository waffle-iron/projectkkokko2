using UnityEngine;
using System.Collections;

public class UnityTouchService : MonoBehaviour, IInputTouchService
{
    [SerializeField]
    private Camera camera;

    public TouchData[] touch
    {
        get {
            return _touchData;
        }
    }

    private TouchData[] _touchData = null;

    // Use this for initialization
    void Start ()
    {
        _touchData = null;
    }

    // Update is called once per frame
    void Update ()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            var newTouches = new TouchData[1];
            var screenPos = Input.mousePosition;
            var worldPos = (Vector3)screenPos;
            worldPos.z = camera.transform.position.z;
            worldPos = camera.ScreenToWorldPoint(worldPos);
            newTouches[0] = new TouchData(1, screenPos, worldPos, TouchPhase.Began);
            _touchData = newTouches;
        }
#elif UNITY_ANDROID || UNITY_IOS
        if (Input.touchCount > 0)
        {
            var newTouches = new TouchData[Input.touchCount];
            for (int ctr = 0; ctr < Input.touchCount; ctr++)
            {
                var touch = Input.GetTouch(ctr);
                var screenPos = touch.position;
                var worldPos = (Vector3)screenPos;
                worldPos.z = camera.transform.position.z;
                worldPos = camera.ScreenToWorldPoint(worldPos);
                newTouches[ctr] = new TouchData(touch.fingerId, screenPos, worldPos, touch.phase);
            }
            _touchData = newTouches;
        }
#endif  
        else
        {
            _touchData = null;
        }
    }
}
