//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public MaxComponent max { get { return (MaxComponent)GetComponent(GameComponentsLookup.Max); } }
    public bool hasMax { get { return HasComponent(GameComponentsLookup.Max); } }

    public void AddMax(CodeStage.AntiCheat.ObscuredTypes.ObscuredInt newAmount) {
        var index = GameComponentsLookup.Max;
        var component = CreateComponent<MaxComponent>(index);
        component.amount = newAmount;
        AddComponent(index, component);
    }

    public void ReplaceMax(CodeStage.AntiCheat.ObscuredTypes.ObscuredInt newAmount) {
        var index = GameComponentsLookup.Max;
        var component = CreateComponent<MaxComponent>(index);
        component.amount = newAmount;
        ReplaceComponent(index, component);
    }

    public void RemoveMax() {
        RemoveComponent(GameComponentsLookup.Max);
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
public partial class GameEntity : IMaxEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherMax;

    public static Entitas.IMatcher<GameEntity> Max {
        get {
            if (_matcherMax == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Max);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherMax = matcher;
            }

            return _matcherMax;
        }
    }
}
