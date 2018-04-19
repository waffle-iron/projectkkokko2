//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public PlaceablePositionComponent placeablePosition { get { return (PlaceablePositionComponent)GetComponent(GameComponentsLookup.PlaceablePosition); } }
    public bool hasPlaceablePosition { get { return HasComponent(GameComponentsLookup.PlaceablePosition); } }

    public void AddPlaceablePosition(UnityEngine.Vector3 newCurrent) {
        var index = GameComponentsLookup.PlaceablePosition;
        var component = CreateComponent<PlaceablePositionComponent>(index);
        component.current = newCurrent;
        AddComponent(index, component);
    }

    public void ReplacePlaceablePosition(UnityEngine.Vector3 newCurrent) {
        var index = GameComponentsLookup.PlaceablePosition;
        var component = CreateComponent<PlaceablePositionComponent>(index);
        component.current = newCurrent;
        ReplaceComponent(index, component);
    }

    public void RemovePlaceablePosition() {
        RemoveComponent(GameComponentsLookup.PlaceablePosition);
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

    static Entitas.IMatcher<GameEntity> _matcherPlaceablePosition;

    public static Entitas.IMatcher<GameEntity> PlaceablePosition {
        get {
            if (_matcherPlaceablePosition == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.PlaceablePosition);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherPlaceablePosition = matcher;
            }

            return _matcherPlaceablePosition;
        }
    }
}
