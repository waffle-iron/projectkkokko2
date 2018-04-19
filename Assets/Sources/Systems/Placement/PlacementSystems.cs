using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class PlacementSystems : Feature
{
    public PlacementSystems (Contexts contexts) : base("Placement Systems")
    {
        //Add(system here);

        Add(new ApartmentPlacementInitPosReactiveSystem(contexts));
        Add(new ApartmentPlacementCollisionCheckerReactiveSystem(contexts));
        Add(new ApartmentPlacementReleaseReactiveSystem(contexts));

        Add(new PlacementPositionReactiveSystem(contexts));

        Add(new SavePlacementReactiveSystem(contexts));
        Add(new LoadPlaceablePositionReactiveSystem(contexts));
    }
}