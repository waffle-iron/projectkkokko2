﻿using Entitas;
using System;
using System.Collections.Generic;


public interface IViewService
{
    void Instantiate (IContext context, IEntity entity, string name);
    IObservable<T> GetAsset<T> (string name) where T : UnityEngine.Object;
    IObservable<bool> GetAsset<T> (string name, Action<T> action) where T : UnityEngine.Object;
    IObservable<bool> CombineLoadAssets (IObservable<bool>[] observables);
    IObservable<bool> Populate (bool includeSceneObjects, string[] bundles = null);
    void Clean ();
    void Unload (string bundle);
}

