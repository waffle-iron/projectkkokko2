//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class CommandEntity {

    public CommandMoveableListenerComponent commandMoveableListener { get { return (CommandMoveableListenerComponent)GetComponent(CommandComponentsLookup.CommandMoveableListener); } }
    public bool hasCommandMoveableListener { get { return HasComponent(CommandComponentsLookup.CommandMoveableListener); } }

    public void AddCommandMoveableListener(System.Collections.Generic.List<ICommandMoveableListener> newValue) {
        var index = CommandComponentsLookup.CommandMoveableListener;
        var component = CreateComponent<CommandMoveableListenerComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceCommandMoveableListener(System.Collections.Generic.List<ICommandMoveableListener> newValue) {
        var index = CommandComponentsLookup.CommandMoveableListener;
        var component = CreateComponent<CommandMoveableListenerComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveCommandMoveableListener() {
        RemoveComponent(CommandComponentsLookup.CommandMoveableListener);
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

    static Entitas.IMatcher<CommandEntity> _matcherCommandMoveableListener;

    public static Entitas.IMatcher<CommandEntity> CommandMoveableListener {
        get {
            if (_matcherCommandMoveableListener == null) {
                var matcher = (Entitas.Matcher<CommandEntity>)Entitas.Matcher<CommandEntity>.AllOf(CommandComponentsLookup.CommandMoveableListener);
                matcher.componentNames = CommandComponentsLookup.componentNames;
                _matcherCommandMoveableListener = matcher;
            }

            return _matcherCommandMoveableListener;
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

    public void AddCommandMoveableListener(ICommandMoveableListener value) {
        var listeners = hasCommandMoveableListener
            ? commandMoveableListener.value
            : new System.Collections.Generic.List<ICommandMoveableListener>();
        listeners.Add(value);
        ReplaceCommandMoveableListener(listeners);
    }

    public void RemoveCommandMoveableListener(ICommandMoveableListener value, bool removeComponentWhenEmpty = true) {
        var listeners = commandMoveableListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveCommandMoveableListener();
        } else {
            ReplaceCommandMoveableListener(listeners);
        }
    }
}
