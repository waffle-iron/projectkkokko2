//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    public CreateEntityComponent createEntity { get { return (CreateEntityComponent)GetComponent(InputComponentsLookup.CreateEntity); } }
    public bool hasCreateEntity { get { return HasComponent(InputComponentsLookup.CreateEntity); } }

    public void AddCreateEntity(EntityCfgID newId) {
        var index = InputComponentsLookup.CreateEntity;
        var component = CreateComponent<CreateEntityComponent>(index);
        component.id = newId;
        AddComponent(index, component);
    }

    public void ReplaceCreateEntity(EntityCfgID newId) {
        var index = InputComponentsLookup.CreateEntity;
        var component = CreateComponent<CreateEntityComponent>(index);
        component.id = newId;
        ReplaceComponent(index, component);
    }

    public void RemoveCreateEntity() {
        RemoveComponent(InputComponentsLookup.CreateEntity);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiInterfaceGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity : ICreateEntityEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherCreateEntity;

    public static Entitas.IMatcher<InputEntity> CreateEntity {
        get {
            if (_matcherCreateEntity == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.CreateEntity);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherCreateEntity = matcher;
            }

            return _matcherCreateEntity;
        }
    }
}
