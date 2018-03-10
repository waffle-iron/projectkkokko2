using System;
using System.Collections.Generic;
using UnityEngine;


public class UnityTimeService : ITimeService
{
    public UnityTimeService ()
    {
    }

    public float delta
    {
        get {
            return Time.deltaTime;
        }
    }

    public float unscaledDelta
    {
        get { return Time.unscaledDeltaTime; }
    }

    public double timeFromGameStart
    {
        get { return Time.realtimeSinceStartup; }
    }
}

