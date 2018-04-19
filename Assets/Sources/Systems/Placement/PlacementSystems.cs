using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class PlacementSystems : Feature
{
    public PlacementSystems (Contexts contexts) : base("Placement Systems")
    {
        //Add(system here);
        Add(new ApartmentPlacementCollisionCheckerReactiveSystem(contexts));
    }
}