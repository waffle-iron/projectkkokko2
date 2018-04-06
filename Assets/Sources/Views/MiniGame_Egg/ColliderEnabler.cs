
using UnityEngine;
using System.Collections;

public class ColliderEnabler : MonoBehaviour
{
    [SerializeField]
    private Collider2D[] cols;

    [SerializeField]
    private bool _isInverse = false;

    private void OnTriggerEnter2D (Collider2D collision)
    {
        foreach (var col in cols)
        {
            col.enabled = _isInverse ? false : true;
        }
    }

    public void Reset ()
    {
        foreach (var col in cols)
        {
            col.enabled = _isInverse ? true: false;
        }
    }
}
