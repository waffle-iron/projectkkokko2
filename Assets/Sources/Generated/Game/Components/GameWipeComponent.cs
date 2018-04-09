//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public WipeComponent wipe { get { return (WipeComponent)GetComponent(GameComponentsLookup.Wipe); } }
    public bool hasWipe { get { return HasComponent(GameComponentsLookup.Wipe); } }

    public void AddWipe(float newDeltaAmountToComplete) {
        var index = GameComponentsLookup.Wipe;
        var component = CreateComponent<WipeComponent>(index);
        component.deltaAmountToComplete = newDeltaAmountToComplete;
        AddComponent(index, component);
    }

    public void ReplaceWipe(float newDeltaAmountToComplete) {
        var index = GameComponentsLookup.Wipe;
        var component = CreateComponent<WipeComponent>(index);
        component.deltaAmountToComplete = newDeltaAmountToComplete;
        ReplaceComponent(index, component);
    }

    public void RemoveWipe() {
        RemoveComponent(GameComponentsLookup.Wipe);
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
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherWipe;

    public static Entitas.IMatcher<GameEntity> Wipe {
        get {
            if (_matcherWipe == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Wipe);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherWipe = matcher;
            }

            return _matcherWipe;
        }
    }
}
