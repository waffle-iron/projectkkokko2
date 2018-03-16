//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class CommandEntity {

    public CommandEquippedListenerComponent commandEquippedListener { get { return (CommandEquippedListenerComponent)GetComponent(CommandComponentsLookup.CommandEquippedListener); } }
    public bool hasCommandEquippedListener { get { return HasComponent(CommandComponentsLookup.CommandEquippedListener); } }

    public void AddCommandEquippedListener(System.Collections.Generic.List<ICommandEquippedListener> newValue) {
        var index = CommandComponentsLookup.CommandEquippedListener;
        var component = CreateComponent<CommandEquippedListenerComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceCommandEquippedListener(System.Collections.Generic.List<ICommandEquippedListener> newValue) {
        var index = CommandComponentsLookup.CommandEquippedListener;
        var component = CreateComponent<CommandEquippedListenerComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveCommandEquippedListener() {
        RemoveComponent(CommandComponentsLookup.CommandEquippedListener);
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

    static Entitas.IMatcher<CommandEntity> _matcherCommandEquippedListener;

    public static Entitas.IMatcher<CommandEntity> CommandEquippedListener {
        get {
            if (_matcherCommandEquippedListener == null) {
                var matcher = (Entitas.Matcher<CommandEntity>)Entitas.Matcher<CommandEntity>.AllOf(CommandComponentsLookup.CommandEquippedListener);
                matcher.componentNames = CommandComponentsLookup.componentNames;
                _matcherCommandEquippedListener = matcher;
            }

            return _matcherCommandEquippedListener;
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

    public void AddCommandEquippedListener(ICommandEquippedListener value) {
        var listeners = hasCommandEquippedListener
            ? commandEquippedListener.value
            : new System.Collections.Generic.List<ICommandEquippedListener>();
        listeners.Add(value);
        ReplaceCommandEquippedListener(listeners);
    }

    public void RemoveCommandEquippedListener(ICommandEquippedListener value, bool removeComponentWhenEmpty = true) {
        var listeners = commandEquippedListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveCommandEquippedListener();
        } else {
            ReplaceCommandEquippedListener(listeners);
        }
    }
}
