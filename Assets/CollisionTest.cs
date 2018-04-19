using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class CollisionTest : MonoBehaviour
{

    private HashSet<GameObject> _collisions = new HashSet<GameObject>();

    // Use this for initialization
    void Start ()
    {
        this.OnTriggerEnter2DAsObservable().ThrottleFrame(1).Subscribe(_ =>
        {
            if (_collisions.Count > 0)
            {
                Debug.Log(_collisions.Count);
                _collisions.Clear();
            }

        });
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        _collisions.Add(collision.gameObject);
    }

}
