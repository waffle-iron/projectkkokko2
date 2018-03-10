using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class MainController : MonoBehaviour
{
    private Contexts _contexts;
    private Systems _systems;

    private void Awake ()
    {
        _contexts = Contexts.sharedInstance;
        _systems = CreateSystems(_contexts, CreateServices(_contexts));
    }

    private void Start ()
    {
        _systems.Initialize();
    }

    private void Update ()
    {
        _systems.Execute();
        _systems.Cleanup();
    }

    private void OnApplicationPause (bool pause)
    {
        _systems.Execute();
        _systems.Cleanup();
    }

    private void OnDestroy ()
    {
        _systems.TearDown();
        _systems.DeactivateReactiveSystems();
        _systems.ClearReactiveSystems();
    }

    private Systems CreateSystems (Contexts contexts, Services services)
    {
        return new Feature("Overall Systems")
            .Add(new ServiceSystems(contexts, services))
            .Add(new GeneralSystems(contexts))
            .Add(new EventSystems(contexts));

    }

    private Services CreateServices (Contexts contexts)
    {
        return new Services
            (
            new UnityLoadSceneService(contexts),
            new UnityViewService()
            );
    }
}
