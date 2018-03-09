using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class ServiceSystems : Feature
{
    public ServiceSystems (Contexts contexts, Services services) : base("Service Systems")
    {
        //Add(system here);
        Add(new RegisterSceneServiceSystem(contexts, services.scene));
        Add(new RegisterViewServiceSystem(contexts, services.view));
    }
}