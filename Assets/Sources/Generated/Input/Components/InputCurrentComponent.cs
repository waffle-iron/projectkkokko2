//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    public CurrentComponent current { get { return (CurrentComponent)GetComponent(InputComponentsLookup.Current); } }
    public bool hasCurrent { get { return HasComponent(InputComponentsLookup.Current); } }

    public void AddCurrent(int newAmount) {
        var index = InputComponentsLookup.Current;
        var component = CreateComponent<CurrentComponent>(index);
        component.amount = newAmount;
        AddComponent(index, component);
    }

    public void ReplaceCurrent(int newAmount) {
        var index = InputComponentsLookup.Current;
        var component = CreateComponent<CurrentComponent>(index);
        component.amount = newAmount;
        ReplaceComponent(index, component);
    }

    public void RemoveCurrent() {
        RemoveComponent(InputComponentsLookup.Current);
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
public partial class InputEntity : ICurrentEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherCurrent;

    public static Entitas.IMatcher<InputEntity> Current {
        get {
            if (_matcherCurrent == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.Current);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherCurrent = matcher;
            }

            return _matcherCurrent;
        }
    }
}
