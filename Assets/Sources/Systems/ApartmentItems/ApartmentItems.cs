using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class ApartmentItems : Feature
{
    public ApartmentItems (Contexts contexts) : base("Apartment Items Systems")
    {
        Add(new GridToApartmentItemCollisionEnterCheckerReactiveSystem(contexts));
        Add(new GridToApartmentItemCollisionExitCheckerReactiveSystem(contexts));
        Add(new ApartmentItemSaveGridIDReactiveSystem(contexts));
    }
}