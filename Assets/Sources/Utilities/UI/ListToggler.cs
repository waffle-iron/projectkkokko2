using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ListToggler : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _lists;

    [SerializeField]
    private string _default;

    public void TurnOn (string name)
    {
        foreach (var list in _lists)
        {
            if (list.name == name) { list.SetActive(true); }
            else { list.SetActive(false); }
        }
    }

    private void OnEnable ()
    {
        TurnOn(_default);
    }
}
