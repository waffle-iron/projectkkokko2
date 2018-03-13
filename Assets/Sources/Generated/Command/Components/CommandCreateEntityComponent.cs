//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class CommandEntity {

    public CreateEntityComponent createEntity { get { return (CreateEntityComponent)GetComponent(CommandComponentsLookup.CreateEntity); } }
    public bool hasCreateEntity { get { return HasComponent(CommandComponentsLookup.CreateEntity); } }

    public void AddCreateEntity(EntityCfgID newId) {
        var index = CommandComponentsLookup.CreateEntity;
        var component = CreateComponent<CreateEntityComponent>(index);
        component.id = newId;
        AddComponent(index, component);
    }

    public void ReplaceCreateEntity(EntityCfgID newId) {
        var index = CommandComponentsLookup.CreateEntity;
        var component = CreateComponent<CreateEntityComponent>(index);
        component.id = newId;
        ReplaceComponent(index, component);
    }

    public void RemoveCreateEntity() {
        RemoveComponent(CommandComponentsLookup.CreateEntity);
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
public partial class CommandEntity : ICreateEntityEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class CommandMatcher {

    static Entitas.IMatcher<CommandEntity> _matcherCreateEntity;

    public static Entitas.IMatcher<CommandEntity> CreateEntity {
        get {
            if (_matcherCreateEntity == null) {
                var matcher = (Entitas.Matcher<CommandEntity>)Entitas.Matcher<CommandEntity>.AllOf(CommandComponentsLookup.CreateEntity);
                matcher.componentNames = CommandComponentsLookup.componentNames;
                _matcherCreateEntity = matcher;
            }

            return _matcherCreateEntity;
        }
    }
}
