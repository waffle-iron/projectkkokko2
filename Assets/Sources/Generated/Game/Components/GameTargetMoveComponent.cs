//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public TargetMoveComponent targetMove { get { return (TargetMoveComponent)GetComponent(GameComponentsLookup.TargetMove); } }
    public bool hasTargetMove { get { return HasComponent(GameComponentsLookup.TargetMove); } }

    public void AddTargetMove(UnityEngine.Vector3 newPosition, float newStopDistance) {
        var index = GameComponentsLookup.TargetMove;
        var component = CreateComponent<TargetMoveComponent>(index);
        component.position = newPosition;
        component.stopDistance = newStopDistance;
        AddComponent(index, component);
    }

    public void ReplaceTargetMove(UnityEngine.Vector3 newPosition, float newStopDistance) {
        var index = GameComponentsLookup.TargetMove;
        var component = CreateComponent<TargetMoveComponent>(index);
        component.position = newPosition;
        component.stopDistance = newStopDistance;
        ReplaceComponent(index, component);
    }

    public void RemoveTargetMove() {
        RemoveComponent(GameComponentsLookup.TargetMove);
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
public partial class GameEntity : ITargetMoveEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherTargetMove;

    public static Entitas.IMatcher<GameEntity> TargetMove {
        get {
            if (_matcherTargetMove == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.TargetMove);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherTargetMove = matcher;
            }

            return _matcherTargetMove;
        }
    }
}
