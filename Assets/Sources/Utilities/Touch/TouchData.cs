using System;
using System.Collections.Generic;
using UnityEngine;


public struct TouchData
{
    public int Id { get; private set; }
    public Vector3 ScreenPosition { get; private set; }
    public Vector3 WorldPosition { get; private set; }
    public TouchPhase Phase { get; private set; }

    public static TouchData Empty
    {
        get {
            return new TouchData(-1, Vector3.zero, Vector3.zero, TouchPhase.Canceled);
        }
    }

    public TouchData (int id, Vector3 screenPos, Vector3 worldPos, TouchPhase phase)
    {
        this.Id = id;
        this.ScreenPosition = screenPos;
        this.WorldPosition = worldPos;
        this.Phase = phase;
    }
}

