using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class NeedSystems : Feature
{
    public NeedSystems (Contexts contexts) : base("Need Systems")
    {
        Add(new PoopTriggeredReactiveSystem(contexts)); //custom need logic
        Add(new PoopModifyHygieneReactiveSystem(contexts));

        Add(new NeedInputReactiveSystem(contexts));
        Add(new NeedInputSwitchReactiveSystem(contexts));
        Add(new NeedCommandReactiveSystem(contexts));

        Add(new NeedTriggerReactiveSystem(contexts));
        Add(new NeedDeductReactiveSystem(contexts));


        Add(new NeedUnscheduleNotificationReactiveSystem(contexts));
        Add(new NeedScheduleNotificationReactiveSystem(contexts));
    }
}