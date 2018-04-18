using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;
using System;

public class GridSquare : MonoBehaviour
{
    public event Action<GridSquare> OnTrigger;

    public Vector2 index;

    public uint otherID { get; private set; }

    public void OnTriggerEnter2D (Collider2D collision)
    {
        var view = collision.GetComponent<View>();

        if (view != null && OnTrigger != null)
        {
            this.otherID = view.ID;
            OnTrigger(this);
        }
    }

}
