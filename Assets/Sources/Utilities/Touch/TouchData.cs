using System;
using System.Collections.Generic;
using UnityEngine;


public struct TouchData
{
    public int Id { get; private set; }
    public Vector3 DeltaScreenPosition { get; private set; }
    public Vector3 DeltaWorldPosition { get; private set; }
    public Vector3 ScreenPosition { get; private set; }
    public Vector3 WorldPosition { get; private set; }
    public TouchPhase Phase { get; private set; }
    public RaycastHit2D[] Hits { get; private set; }
    public double TouchTime { get; private set; }

    public static TouchData Empty
    {
        get {
            return new TouchData(-1, Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero, TouchPhase.Canceled, 0, null);
        }
    }

    public TouchData (int id, Vector3 screenPos, Vector3 worldPos, Vector3 deltaScreenPos, Vector3 deltaWorldPos, TouchPhase phase, double touchTime, RaycastHit2D[] hits)
    {
        this.Id = id;
        this.ScreenPosition = screenPos;
        this.WorldPosition = worldPos;
        this.DeltaScreenPosition = deltaScreenPos;
        this.DeltaWorldPosition = deltaWorldPos;
        this.Phase = phase;
        this.TouchTime = touchTime;
        this.Hits = hits;
    }
}

