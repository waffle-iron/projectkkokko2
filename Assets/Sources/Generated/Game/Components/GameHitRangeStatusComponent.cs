//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public HitRangeStatusComponent hitRangeStatus { get { return (HitRangeStatusComponent)GetComponent(GameComponentsLookup.HitRangeStatus); } }
    public bool hasHitRangeStatus { get { return HasComponent(GameComponentsLookup.HitRangeStatus); } }

    public void AddHitRangeStatus(bool newState) {
        var index = GameComponentsLookup.HitRangeStatus;
        var component = CreateComponent<HitRangeStatusComponent>(index);
        component.state = newState;
        AddComponent(index, component);
    }

    public void ReplaceHitRangeStatus(bool newState) {
        var index = GameComponentsLookup.HitRangeStatus;
        var component = CreateComponent<HitRangeStatusComponent>(index);
        component.state = newState;
        ReplaceComponent(index, component);
    }

    public void RemoveHitRangeStatus() {
        RemoveComponent(GameComponentsLookup.HitRangeStatus);
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

    static Entitas.IMatcher<GameEntity> _matcherHitRangeStatus;

    public static Entitas.IMatcher<GameEntity> HitRangeStatus {
        get {
            if (_matcherHitRangeStatus == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.HitRangeStatus);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherHitRangeStatus = matcher;
            }

            return _matcherHitRangeStatus;
        }
    }
}
