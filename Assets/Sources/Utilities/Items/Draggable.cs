using UnityEngine;
using System.Collections;
using System.Linq;

public class Draggable : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _sprite;

    private bool _drag = false;

    private IInputTouchService _service;

    private void Start ()
    {
        _service = Contexts.sharedInstance.meta.touchService.instance;
        if (_service == null)
        {
            Debug.LogError("touch service is null");
        }
    }

    void Update ()
    {
        if (_service != null && _service.touch != null)
        {
            if (_service.touch[0].Phase == TouchPhase.Began && _service.touch[0].Hits.Select(raycast => raycast.transform).Contains(this.transform))
            {
                _drag = true;
            }
            else if (_service.touch[0].Phase == TouchPhase.Ended)
            {
                _drag = false;
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
