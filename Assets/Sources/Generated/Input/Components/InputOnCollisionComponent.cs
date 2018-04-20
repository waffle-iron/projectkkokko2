//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    public OnCollisionComponent onCollision { get { return (OnCollisionComponent)GetComponent(InputComponentsLookup.OnCollision); } }
    public bool hasOnCollision { get { return HasComponent(InputComponentsLookup.OnCollision); } }

    public void AddOnCollision(CollisionData[] newData) {
        var index = InputComponentsLookup.OnCollision;
        var component = CreateComponent<OnCollisionComponent>(index);
        component.data = newData;
        AddComponent(index, component);
    }

    public void ReplaceOnCollision(CollisionData[] newData) {
        var index = InputComponentsLookup.OnCollision;
        var component = CreateComponent<OnCollisionComponent>(index);
        component.data = newData;
        ReplaceComponent(index, component);
    }

    public void RemoveOnCollision() {
        RemoveComponent(InputComponentsLookup.OnCollision);
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
public partial class InputEntity : IOnCollisionEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherOnCollision;

    public static Entitas.IMatcher<InputEntity> OnCollision {
        get {
            if (_matcherOnCollision == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.OnCollision);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherOnCollision = matcher;
            }

            return _matcherOnCollision;
        }
    }
}
