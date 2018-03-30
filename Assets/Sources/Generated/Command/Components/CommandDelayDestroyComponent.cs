//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class CommandEntity {

    public DelayDestroyComponent delayDestroy { get { return (DelayDestroyComponent)GetComponent(CommandComponentsLookup.DelayDestroy); } }
    public bool hasDelayDestroy { get { return HasComponent(CommandComponentsLookup.DelayDestroy); } }

    public void AddDelayDestroy(uint newFrames) {
        var index = CommandComponentsLookup.DelayDestroy;
        var component = CreateComponent<DelayDestroyComponent>(index);
        component.frames = newFrames;
        AddComponent(index, component);
    }

    public void ReplaceDelayDestroy(uint newFrames) {
        var index = CommandComponentsLookup.DelayDestroy;
        var component = CreateComponent<DelayDestroyComponent>(index);
        component.frames = newFrames;
        ReplaceComponent(index, component);
    }

    public void RemoveDelayDestroy() {
        RemoveComponent(CommandComponentsLookup.DelayDestroy);
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
public partial class CommandEntity : IDelayDestroyEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class CommandMatcher {

    static Entitas.IMatcher<CommandEntity> _matcherDelayDestroy;

    public static Entitas.IMatcher<CommandEntity> DelayDestroy {
        get {
            if (_matcherDelayDestroy == null) {
                var matcher = (Entitas.Matcher<CommandEntity>)Entitas.Matcher<CommandEntity>.AllOf(CommandComponentsLookup.DelayDestroy);
                matcher.componentNames = CommandComponentsLookup.componentNames;
                _matcherDelayDestroy = matcher;
            }

            return _matcherDelayDestroy;
        }
    }
}
