using UnityEngine;
using System.Collections;

public class UnityPauseService : MonoBehaviour, IPauseService
{
    [SerializeField]
    private bool _isEnabled = true;

    private bool _state = false;

    public bool state
    {
        get {
            return _state;
        }
    }

    void Start ()
    {
        _state = false;
    }

    private void OnApplicationFocus (bool focus)
    {
        if (_isEnabled)
        {
            _state = !focus;
        }
    }
}
