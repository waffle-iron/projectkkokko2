using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class MainController : MonoBehaviour
{
    [SceneName, SerializeField]
    private string _rootScene;
    [SerializeField]
    private string[] _configPath;
    [SerializeField]
    private string[] _viewPaths;

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

    //private void OnApplicationPause (bool pause)
    //{
    //    _systems.Execute();
    //    _systems.Cleanup();
    //}

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
            .Add(new InitializeGeneralSystems(contexts)) //all initialization sa general diri para walay null reference if accessed by custom systems

            .Add(new NeedSystems(contexts))

            .Add(new GeneralSystems(contexts)) //executed after all custom systems para ma pick up before cleanup sa destroy systems
            .Add(new EventSystems(contexts));

    }

    private Services CreateServices (Contexts contexts)
    {
        return new Services
            (
            new UnityLoadSceneService(contexts, _rootScene),
            new UnityViewService(true, _viewPaths),
            new JSONSaveLoadService(),
            new UnityTimeService(),
            new UnityEntityService(_configPath, contexts),
            GetComponentInChildren<UnityPauseService>(),
            new UltimateMobileNotificationService(),
            new UnityDebugService()
            );
    }
}
