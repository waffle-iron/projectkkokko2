using Entitas;
using System;
using System.Collections.Generic;


public interface IViewService
{
    void Instantiate (IContext context, IEntity entity, string name);
    IObservable<T> GetAsset<T> (string name) where T : UnityEngine.Object;
    IObservable<bool> Populate (bool includeSceneObjects, string[] bundles = null);
    void Clean ();
    void Unload (string bundle);
}

