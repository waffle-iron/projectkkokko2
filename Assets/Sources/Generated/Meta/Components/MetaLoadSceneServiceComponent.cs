//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class MetaContext {

    public MetaEntity loadSceneServiceEntity { get { return GetGroup(MetaMatcher.LoadSceneService).GetSingleEntity(); } }
    public LoadSceneServiceComponent loadSceneService { get { return loadSceneServiceEntity.loadSceneService; } }
    public bool hasLoadSceneService { get { return loadSceneServiceEntity != null; } }

    public MetaEntity SetLoadSceneService(ILoadSceneService newInstance) {
        if (hasLoadSceneService) {
            throw new Entitas.EntitasException("Could not set LoadSceneService!\n" + this + " already has an entity with LoadSceneServiceComponent!",
                "You should check if the context already has a loadSceneServiceEntity before setting it or use context.ReplaceLoadSceneService().");
        }
        var entity = CreateEntity();
        entity.AddLoadSceneService(newInstance);
        return entity;
    }

    public void ReplaceLoadSceneService(ILoadSceneService newInstance) {
        var entity = loadSceneServiceEntity;
        if (entity == null) {
            entity = SetLoadSceneService(newInstance);
        } else {
            entity.ReplaceLoadSceneService(newInstance);
        }
    }

    public void RemoveLoadSceneService() {
        loadSceneServiceEntity.Destroy();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class MetaEntity {

    public LoadSceneServiceComponent loadSceneService { get { return (LoadSceneServiceComponent)GetComponent(MetaComponentsLookup.LoadSceneService); } }
    public bool hasLoadSceneService { get { return HasComponent(MetaComponentsLookup.LoadSceneService); } }

    public void AddLoadSceneService(ILoadSceneService newInstance) {
        var index = MetaComponentsLookup.LoadSceneService;
        var component = CreateComponent<LoadSceneServiceComponent>(index);
        component.instance = newInstance;
        AddComponent(index, component);
    }

    public void ReplaceLoadSceneService(ILoadSceneService newInstance) {
        var index = MetaComponentsLookup.LoadSceneService;
        var component = CreateComponent<LoadSceneServiceComponent>(index);
        component.instance = newInstance;
        ReplaceComponent(index, component);
    }

    public void RemoveLoadSceneService() {
        RemoveComponent(MetaComponentsLookup.LoadSceneService);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class MetaMatcher {

    static Entitas.IMatcher<MetaEntity> _matcherLoadSceneService;

    public static Entitas.IMatcher<MetaEntity> LoadSceneService {
        get {
            if (_matcherLoadSceneService == null) {
                var matcher = (Entitas.Matcher<MetaEntity>)Entitas.Matcher<MetaEntity>.AllOf(MetaComponentsLookup.LoadSceneService);
                matcher.componentNames = MetaComponentsLookup.componentNames;
                _matcherLoadSceneService = matcher;
            }

            return _matcherLoadSceneService;
        }
    }
}
