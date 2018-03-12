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
        Add(new RegisterSaveServiceSystem(contexts, services.save));
        Add(new RegisterTimeServiceSystem(contexts, services.time));
        Add(new RegisterEntityServiceSystem(contexts, services.entity));
        Add(new RegisterPauseServiceSystem(contexts, services.pause));
        Add(new RegisterNotificationService(contexts, services.notif));
        Add(new RegisterDebugServiceSystem(contexts, services.debug));
    }
}