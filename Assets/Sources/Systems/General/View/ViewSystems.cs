using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class ViewSystems : Feature
{
    public ViewSystems (Contexts contexts) : base("View Systems")
    {
        //Add(system here);
        Add(new AddViewReactiveSystem(contexts));
        Add(new ReloadViewsReactiveSystem(contexts));

        Add(new ViewCleanupAddedSystem(contexts));
    }
}