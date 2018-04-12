//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class CommandEntity {

    public HudChangeStateComponent hudChangeState { get { return (HudChangeStateComponent)GetComponent(CommandComponentsLookup.HudChangeState); } }
    public bool hasHudChangeState { get { return HasComponent(CommandComponentsLookup.HudChangeState); } }

    public void AddHudChangeState(bool newNewState, bool newAll) {
        var index = CommandComponentsLookup.HudChangeState;
        var component = CreateComponent<HudChangeStateComponent>(index);
        component.newState = newNewState;
        component.all = newAll;
        AddComponent(index, component);
    }

    public void ReplaceHudChangeState(bool newNewState, bool newAll) {
        var index = CommandComponentsLookup.HudChangeState;
        var component = CreateComponent<HudChangeStateComponent>(index);
        component.newState = newNewState;
        component.all = newAll;
        ReplaceComponent(index, component);
    }

    public void RemoveHudChangeState() {
        RemoveComponent(CommandComponentsLookup.HudChangeState);
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
public partial class CommandEntity : IHudChangeStateEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class CommandMatcher {

    static Entitas.IMatcher<CommandEntity> _matcherHudChangeState;

    public static Entitas.IMatcher<CommandEntity> HudChangeState {
        get {
            if (_matcherHudChangeState == null) {
                var matcher = (Entitas.Matcher<CommandEntity>)Entitas.Matcher<CommandEntity>.AllOf(CommandComponentsLookup.HudChangeState);
                matcher.componentNames = CommandComponentsLookup.componentNames;
                _matcherHudChangeState = matcher;
            }

            return _matcherHudChangeState;
        }
    }
}
