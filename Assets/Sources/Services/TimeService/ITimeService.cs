using System;
using System.Collections.Generic;


public interface ITimeService
{
    float delta { get; }
    float unscaledDelta { get; }
    double timeFromGameStart { get; }
}

