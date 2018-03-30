//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    public InputOnCollisionListenerComponent inputOnCollisionListener { get { return (InputOnCollisionListenerComponent)GetComponent(InputComponentsLookup.InputOnCollisionListener); } }
    public bool hasInputOnCollisionListener { get { return HasComponent(InputComponentsLookup.InputOnCollisionListener); } }

    public void AddInputOnCollisionListener(System.Collections.Generic.List<IInputOnCollisionListener> newValue) {
        var index = InputComponentsLookup.InputOnCollisionListener;
        var component = CreateComponent<InputOnCollisionListenerComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceInputOnCollisionListener(System.Collections.Generic.List<IInputOnCollisionListener> newValue) {
        var index = InputComponentsLookup.InputOnCollisionListener;
        var component = CreateComponent<InputOnCollisionListenerComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveInputOnCollisionListener() {
        RemoveComponent(InputComponentsLookup.InputOnCollisionListener);
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

    static Entitas.IMatcher<InputEntity> _matcherInputOnCollisionListener;

    public static Entitas.IMatcher<InputEntity> InputOnCollisionListener {
        get {
            if (_matcherInputOnCollisionListener == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.InputOnCollisionListener);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherInputOnCollisionListener = matcher;
            }

            return _matcherInputOnCollisionListener;
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

    public void AddInputOnCollisionListener(IInputOnCollisionListener value) {
        var listeners = hasInputOnCollisionListener
            ? inputOnCollisionListener.value
            : new System.Collections.Generic.List<IInputOnCollisionListener>();
        listeners.Add(value);
        ReplaceInputOnCollisionListener(listeners);
    }

    public void RemoveInputOnCollisionListener(IInputOnCollisionListener value, bool removeComponentWhenEmpty = true) {
        var listeners = inputOnCollisionListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveInputOnCollisionListener();
        } else {
            ReplaceInputOnCollisionListener(listeners);
        }
    }
}
