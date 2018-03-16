//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    public InputAffordListenerComponent inputAffordListener { get { return (InputAffordListenerComponent)GetComponent(InputComponentsLookup.InputAffordListener); } }
    public bool hasInputAffordListener { get { return HasComponent(InputComponentsLookup.InputAffordListener); } }

    public void AddInputAffordListener(System.Collections.Generic.List<IInputAffordListener> newValue) {
        var index = InputComponentsLookup.InputAffordListener;
        var component = CreateComponent<InputAffordListenerComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceInputAffordListener(System.Collections.Generic.List<IInputAffordListener> newValue) {
        var index = InputComponentsLookup.InputAffordListener;
        var component = CreateComponent<InputAffordListenerComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveInputAffordListener() {
        RemoveComponent(InputComponentsLookup.InputAffordListener);
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
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherInputAffordListener;

    public static Entitas.IMatcher<InputEntity> InputAffordListener {
        get {
            if (_matcherInputAffordListener == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.InputAffordListener);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherInputAffordListener = matcher;
            }

            return _matcherInputAffordListener;
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
public partial class InputEntity {

    public void AddInputAffordListener(IInputAffordListener value) {
        var listeners = hasInputAffordListener
            ? inputAffordListener.value
            : new System.Collections.Generic.List<IInputAffordListener>();
        listeners.Add(value);
        ReplaceInputAffordListener(listeners);
    }

    public void RemoveInputAffordListener(IInputAffordListener value, bool removeComponentWhenEmpty = true) {
        var listeners = inputAffordListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveInputAffordListener();
        } else {
            ReplaceInputAffordListener(listeners);
        }
    }
}
