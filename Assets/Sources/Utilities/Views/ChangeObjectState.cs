﻿using UnityEngine;
using System.Collections;

public class ChangeObjectState : MonoBehaviour
{
    [SerializeField]
    private GameObject _target;

    [SerializeField]
    private bool _activate = true;

    public void OnClick ()
    {
        _target.SetActive(_activate);
    }
}
