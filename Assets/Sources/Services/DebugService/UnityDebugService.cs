using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnityDebugService : IDebugService
{
    public void Log(object message)
    {
        Debug.Log(message);
    }

    public void LogError (object message)
    {
        Debug.LogError(message);
    }
}

