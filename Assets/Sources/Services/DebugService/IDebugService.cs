using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface IDebugService
{
    void Log(object message);
    void LogError (object message);
    void LogWarning (object message);
}

