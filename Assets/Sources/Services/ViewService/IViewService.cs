using Entitas;
using System;
using System.Collections.Generic;


public interface IViewService
{
    void Load (IContext context, IEntity entity, string name);
    void Refresh (bool includeSceneObjects, string[] paths = null);
    void Clear ();
}

