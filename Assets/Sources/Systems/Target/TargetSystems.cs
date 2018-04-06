using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class TargetSystems : Feature
{
    public TargetSystems (Contexts contexts) : base("Target Systems")
    {
        //Add(system here);
        Add(new InputTargetableSystem(contexts));
        Add(new InputTouchTargetMovePlayerReactiveSystem(contexts));
        Add(new InputTargetMoveReactiveSystem(contexts));
        Add(new TargetPositionInputReactiveSystem(contexts));

        Add(new CommandTargetMoveReactiveSystem(contexts));
        Add(new TargetPositionCommandReactiveSystem(contexts));

        Add(new CalculateTargetDirectionResultReactiveSystem(contexts));
    }
}