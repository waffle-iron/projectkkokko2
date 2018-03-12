//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public DebugComponent debug { get { return (DebugComponent)GetComponent(GameComponentsLookup.Debug); } }
    public bool hasDebug { get { return HasComponent(GameComponentsLookup.Debug); } }

    public void AddDebug(string newValue) {
        var index = GameComponentsLookup.Debug;
        var component = CreateComponent<DebugComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceDebug(string newValue) {
        var index = GameComponentsLookup.Debug;
        var component = CreateComponent<DebugComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveDebug() {
        RemoveComponent(GameComponentsLookup.Debug);
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
public partial class GameEntity : IDebugEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherDebug;

    public static Entitas.IMatcher<GameEntity> Debug {
        get {
            if (_matcherDebug == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Debug);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherDebug = matcher;
            }

            return _matcherDebug;
        }
    }
}
