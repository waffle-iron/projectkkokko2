using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class AnimationSystems : Feature
{
    public AnimationSystems (Contexts contexts) : base("Animation Systems")
    {
        //Add(system here);
        Add(new AnimationInputReactiveSystem(contexts));
        Add(new AnimationCommandReactiveSystem(contexts));
    }
}