//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class CommandEntity {

    public CommandCurrentListenerComponent commandCurrentListener { get { return (CommandCurrentListenerComponent)GetComponent(CommandComponentsLookup.CommandCurrentListener); } }
    public bool hasCommandCurrentListener { get { return HasComponent(CommandComponentsLookup.CommandCurrentListener); } }

    public void AddCommandCurrentListener(System.Collections.Generic.List<ICommandCurrentListener> newValue) {
        var index = CommandComponentsLookup.CommandCurrentListener;
        var component = CreateComponent<CommandCurrentListenerComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceCommandCurrentListener(System.Collections.Generic.List<ICommandCurrentListener> newValue) {
        var index = CommandComponentsLookup.CommandCurrentListener;
        var component = CreateComponent<CommandCurrentListenerComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveCommandCurrentListener() {
        RemoveComponent(CommandComponentsLookup.CommandCurrentListener);
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
public sealed partial class CommandMatcher {

    static Entitas.IMatcher<CommandEntity> _matcherCommandCurrentListener;

    public static Entitas.IMatcher<CommandEntity> CommandCurrentListener {
        get {
            if (_matcherCommandCurrentListener == null) {
                var matcher = (Entitas.Matcher<CommandEntity>)Entitas.Matcher<CommandEntity>.AllOf(CommandComponentsLookup.CommandCurrentListener);
                matcher.componentNames = CommandComponentsLookup.componentNames;
                _matcherCommandCurrentListener = matcher;
            }

            return _matcherCommandCurrentListener;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class CommandEntity {

    public void AddCommandCurrentListener(ICommandCurrentListener value) {
        var listeners = hasCommandCurrentListener
            ? commandCurrentListener.value
            : new System.Collections.Generic.List<ICommandCurrentListener>();
        listeners.Add(value);
        ReplaceCommandCurrentListener(listeners);
    }

    public void RemoveCommandCurrentListener(ICommandCurrentListener value, bool removeComponentWhenEmpty = true) {
        var listeners = commandCurrentListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveCommandCurrentListener();
        } else {
            ReplaceCommandCurrentListener(listeners);
        }
    }
}
