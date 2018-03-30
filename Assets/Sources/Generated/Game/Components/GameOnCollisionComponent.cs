//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public OnCollisionComponent onCollision { get { return (OnCollisionComponent)GetComponent(GameComponentsLookup.OnCollision); } }
    public bool hasOnCollision { get { return HasComponent(GameComponentsLookup.OnCollision); } }

    public void AddOnCollision(uint newId, CollisionType newType) {
        var index = GameComponentsLookup.OnCollision;
        var component = CreateComponent<OnCollisionComponent>(index);
        component.id = newId;
        component.type = newType;
        AddComponent(index, component);
    }

    public void ReplaceOnCollision(uint newId, CollisionType newType) {
        var index = GameComponentsLookup.OnCollision;
        var component = CreateComponent<OnCollisionComponent>(index);
        component.id = newId;
        component.type = newType;
        ReplaceComponent(index, component);
    }

    public void RemoveOnCollision() {
        RemoveComponent(GameComponentsLookup.OnCollision);
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
public partial class GameEntity : IOnCollisionEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherOnCollision;

    public static Entitas.IMatcher<GameEntity> OnCollision {
        get {
            if (_matcherOnCollision == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.OnCollision);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherOnCollision = matcher;
            }

            return _matcherOnCollision;
        }
    }
}
