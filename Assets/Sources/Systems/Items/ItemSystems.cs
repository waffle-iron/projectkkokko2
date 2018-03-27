﻿
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class ItemSystems : Feature
{
    public ItemSystems (Contexts contexts) : base("Item Systems")
    {
        Add(new AffordReactiveSystem(contexts));

        Add(new CancelInputReactiveSystem(contexts));
        Add(new CancelCommandReactiveSystem(contexts));

        Add(new PurchaseInputReactiveSystem(contexts));
        Add(new PrepurchaseCommandReactiveSystem(contexts));
        Add(new PurchaseCommandReactiveSystem(contexts));

        Add(new PreviewInputReactiveSystem(contexts));
        Add(new PreviewCommandReactiveSystem(contexts));

        Add(new EquipInputReactiveSystem(contexts));
        Add(new EquipCommandReactiveSystem(contexts));

        Add(new EquippedListReactiveSystem(contexts));
        Add(new ReloadEquippedItemsReactiveSystem(contexts));
    }
}