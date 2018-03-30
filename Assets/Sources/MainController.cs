
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class MainController : MonoBehaviour
{
    [SerializeField]
    private string _configPath;
    [SerializeField]
    private bool _isSimulationMode = false;

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
        _contexts.game.isLoadSceneComplete = true;
    }

    private void Update ()
    {
        _systems.Execute();
        _systems.Cleanup();
    }

    private void OnApplicationPause (bool pause)
    {
        //_systems.Execute();
        //_systems.Cleanup();
#if UNITY_IOS || UNITY_ANDROID
        var debug = _contexts.meta.hasDebugService ? _contexts.meta.debugService.instance : null;

        List<LocalNotificationTemplate> scheduled = AndroidNotificationManager.Instance.LoadPendingNotifications();
        foreach (var sched in scheduled)
        {
            debug?.Log($"now:{System.DateTime.Now} utcnow:{System.DateTime.UtcNow}");
            debug?.Log($"id:{sched.id} title:{sched.title} seconds: {sched.fireDate} isFired: {sched.IsFired}");
        }
#endif
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
            .Add(new InitializeGeneralSystems(contexts)) //all initialization sa general diri para walay null reference if accessed by custom systems

            .Add(new FoodSystems(contexts))
            .Add(new ItemSystems(contexts))
            .Add(new NeedSystems(contexts))
            .Add(new TargetSystems(contexts))
            .Add(new MoveSystems(contexts))
            .Add(new CollisionSystems(contexts))

            .Add(new GeneralSystems(contexts)) //executed after all custom systems para ma pick up before cleanup sa destroy systems
            .Add(new EventSystems(contexts));

    }

    private Services CreateServices (Contexts contexts)
    {
        return new Services
            (
            new UnityLoadSceneServiceV2(contexts),
            new UnityViewServiceV2(contexts, _isSimulationMode),
            new JSONSaveLoadService(),
            new UnityTimeService(),
            new UnityEntityService(contexts),
            GetComponentInChildren<UnityPauseService>(),
            new UltimateMobileNotificationService(),
            new UnityDebugService(),
            new UnitySceneSettingService(_configPath),
            GetComponentInChildren<UnityTouchService>()
            );
    }
}
