using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class OsuSystems : Feature
{
    public OsuSystems (Contexts contexts) : base("Osu Systems")
    {
        //Add(system here);
        Add(new UpdateRangeReactiveSystem(contexts));
        Add(new CheckRangeReactiveSystem(contexts));
        Add(new RemoveRangeReactiveSystem(contexts));

    }
}