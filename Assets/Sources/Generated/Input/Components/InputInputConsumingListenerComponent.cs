//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    public InputConsumingListenerComponent inputConsumingListener { get { return (InputConsumingListenerComponent)GetComponent(InputComponentsLookup.InputConsumingListener); } }
    public bool hasInputConsumingListener { get { return HasComponent(InputComponentsLookup.InputConsumingListener); } }

    public void AddInputConsumingListener(System.Collections.Generic.List<IInputConsumingListener> newValue) {
        var index = InputComponentsLookup.InputConsumingListener;
        var component = CreateComponent<InputConsumingListenerComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceInputConsumingListener(System.Collections.Generic.List<IInputConsumingListener> newValue) {
        var index = InputComponentsLookup.InputConsumingListener;
        var component = CreateComponent<InputConsumingListenerComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveInputConsumingListener() {
        RemoveComponent(InputComponentsLookup.InputConsumingListener);
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

    static Entitas.IMatcher<InputEntity> _matcherInputConsumingListener;

    public static Entitas.IMatcher<InputEntity> InputConsumingListener {
        get {
            if (_matcherInputConsumingListener == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.InputConsumingListener);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherInputConsumingListener = matcher;
            }

            return _matcherInputConsumingListener;
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

    public void AddInputConsumingListener(IInputConsumingListener value) {
        var listeners = hasInputConsumingListener
            ? inputConsumingListener.value
            : new System.Collections.Generic.List<IInputConsumingListener>();
        listeners.Add(value);
        ReplaceInputConsumingListener(listeners);
    }

    public void RemoveInputConsumingListener(IInputConsumingListener value, bool removeComponentWhenEmpty = true) {
        var listeners = inputConsumingListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveInputConsumingListener();
        } else {
            ReplaceInputConsumingListener(listeners);
        }
    }
}
