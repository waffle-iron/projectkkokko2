using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class FoodSystems : Feature
{
    public FoodSystems (Contexts contexts) : base("Food Systems")
    {
        //Add(system here);

        Add(new RemoveFromStorageInputReactiveSystem(contexts));
        Add(new ConsumedCompleteInputReactiveSystem(contexts));

        Add(new CommandRemoveFromStorageReactiveSystem(contexts));
        Add(new ConsumedCompleteCommandReactiveSystem(contexts));

        Add(new FoodTimerReactiveSystem(contexts));
        Add(new FoodTriggeredReactiveSystem(contexts));

        Add(new FoodConsumingOnPlayerCollisionReactiveSystem(contexts));
        Add(new FoodCollisionReturnReactiveSystem(contexts));
        Add(new FoodReturnReactiveSystem(contexts));
    }
}