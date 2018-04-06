//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class CommandEntity {

    public CommandActiveDialogListenerComponent commandActiveDialogListener { get { return (CommandActiveDialogListenerComponent)GetComponent(CommandComponentsLookup.CommandActiveDialogListener); } }
    public bool hasCommandActiveDialogListener { get { return HasComponent(CommandComponentsLookup.CommandActiveDialogListener); } }

    public void AddCommandActiveDialogListener(System.Collections.Generic.List<ICommandActiveDialogListener> newValue) {
        var index = CommandComponentsLookup.CommandActiveDialogListener;
        var component = CreateComponent<CommandActiveDialogListenerComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceCommandActiveDialogListener(System.Collections.Generic.List<ICommandActiveDialogListener> newValue) {
        var index = CommandComponentsLookup.CommandActiveDialogListener;
        var component = CreateComponent<CommandActiveDialogListenerComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveCommandActiveDialogListener() {
        RemoveComponent(CommandComponentsLookup.CommandActiveDialogListener);
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

    static Entitas.IMatcher<CommandEntity> _matcherCommandActiveDialogListener;

    public static Entitas.IMatcher<CommandEntity> CommandActiveDialogListener {
        get {
            if (_matcherCommandActiveDialogListener == null) {
                var matcher = (Entitas.Matcher<CommandEntity>)Entitas.Matcher<CommandEntity>.AllOf(CommandComponentsLookup.CommandActiveDialogListener);
                matcher.componentNames = CommandComponentsLookup.componentNames;
                _matcherCommandActiveDialogListener = matcher;
            }

            return _matcherCommandActiveDialogListener;
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

    public void AddCommandActiveDialogListener(ICommandActiveDialogListener value) {
        var listeners = hasCommandActiveDialogListener
            ? commandActiveDialogListener.value
            : new System.Collections.Generic.List<ICommandActiveDialogListener>();
        listeners.Add(value);
        ReplaceCommandActiveDialogListener(listeners);
    }

    public void RemoveCommandActiveDialogListener(ICommandActiveDialogListener value, bool removeComponentWhenEmpty = true) {
        var listeners = commandActiveDialogListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveCommandActiveDialogListener();
        } else {
            ReplaceCommandActiveDialogListener(listeners);
        }
    }
}
