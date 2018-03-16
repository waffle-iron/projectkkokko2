using System;
using System.Collections.Generic;

public interface IPrompt
{
    void Activate (Action yes, Action no, string message);
}

