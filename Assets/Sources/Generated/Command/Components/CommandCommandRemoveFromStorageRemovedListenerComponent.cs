//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class CommandEntity {

    public CommandRemoveFromStorageRemovedListenerComponent commandRemoveFromStorageRemovedListener { get { return (CommandRemoveFromStorageRemovedListenerComponent)GetComponent(CommandComponentsLookup.CommandRemoveFromStorageRemovedListener); } }
    public bool hasCommandRemoveFromStorageRemovedListener { get { return HasComponent(CommandComponentsLookup.CommandRemoveFromStorageRemovedListener); } }

    public void AddCommandRemoveFromStorageRemovedListener(System.Collections.Generic.List<ICommandRemoveFromStorageRemovedListener> newValue) {
        var index = CommandComponentsLookup.CommandRemoveFromStorageRemovedListener;
        var component = CreateComponent<CommandRemoveFromStorageRemovedListenerComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceCommandRemoveFromStorageRemovedListener(System.Collections.Generic.List<ICommandRemoveFromStorageRemovedListener> newValue) {
        var index = CommandComponentsLookup.CommandRemoveFromStorageRemovedListener;
        var component = CreateComponent<CommandRemoveFromStorageRemovedListenerComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveCommandRemoveFromStorageRemovedListener() {
        RemoveComponent(CommandComponentsLookup.CommandRemoveFromStorageRemovedListener);
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

    static Entitas.IMatcher<CommandEntity> _matcherCommandRemoveFromStorageRemovedListener;

    public static Entitas.IMatcher<CommandEntity> CommandRemoveFromStorageRemovedListener {
        get {
            if (_matcherCommandRemoveFromStorageRemovedListener == null) {
                var matcher = (Entitas.Matcher<CommandEntity>)Entitas.Matcher<CommandEntity>.AllOf(CommandComponentsLookup.CommandRemoveFromStorageRemovedListener);
                matcher.componentNames = CommandComponentsLookup.componentNames;
                _matcherCommandRemoveFromStorageRemovedListener = matcher;
            }

            return _matcherCommandRemoveFromStorageRemovedListener;
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

    public void AddCommandRemoveFromStorageRemovedListener(ICommandRemoveFromStorageRemovedListener value) {
        var listeners = hasCommandRemoveFromStorageRemovedListener
            ? commandRemoveFromStorageRemovedListener.value
            : new System.Collections.Generic.List<ICommandRemoveFromStorageRemovedListener>();
        listeners.Add(value);
        ReplaceCommandRemoveFromStorageRemovedListener(listeners);
    }

    public void RemoveCommandRemoveFromStorageRemovedListener(ICommandRemoveFromStorageRemovedListener value, bool removeComponentWhenEmpty = true) {
        var listeners = commandRemoveFromStorageRemovedListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveCommandRemoveFromStorageRemovedListener();
        } else {
            ReplaceCommandRemoveFromStorageRemovedListener(listeners);
        }
    }
}
