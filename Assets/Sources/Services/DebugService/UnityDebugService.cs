using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnityDebugService : IDebugService
{
    public void Log (object message)
    {
#if !NO_DEBUG_SERVICE
        Debug.Log(message);
#endif
    }

    public void LogError (object message)
    {
#if !NO_DEBUG_SERVICE
        Debug.LogError(message);
#endif
    }
}

