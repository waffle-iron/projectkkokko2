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

        Add(new PauseEnergyOnSleepReactiveSystem(contexts));
        Add(new SleepOnCompleteReactiveSystem(contexts));

        Add(new NeedInputReactiveSystem(contexts));
        Add(new NeedInputSwitchReactiveSystem(contexts));
        Add(new NeedCommandReactiveSystem(contexts));

        Add(new NeedFastForwardReactiveSystem(contexts));
        Add(new NeedTriggerReactiveSystem(contexts));
        Add(new NeedDeductionReactiveSystem(contexts));
        Add(new NeedDeductReactiveSystem(contexts));

        Add(new SaveSecondaryNeedReactiveSystem(contexts));
        Add(new SavePrimaryNeedReactiveSystem(contexts));

        Add(new NeedUnscheduleNotificationReactiveSystem(contexts));
        Add(new NeedScheduleNotificationReactiveSystem(contexts));
    }
}