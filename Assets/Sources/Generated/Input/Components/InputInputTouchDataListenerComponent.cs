//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    public InputTouchDataListenerComponent inputTouchDataListener { get { return (InputTouchDataListenerComponent)GetComponent(InputComponentsLookup.InputTouchDataListener); } }
    public bool hasInputTouchDataListener { get { return HasComponent(InputComponentsLookup.InputTouchDataListener); } }

    public void AddInputTouchDataListener(System.Collections.Generic.List<IInputTouchDataListener> newValue) {
        var index = InputComponentsLookup.InputTouchDataListener;
        var component = CreateComponent<InputTouchDataListenerComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceInputTouchDataListener(System.Collections.Generic.List<IInputTouchDataListener> newValue) {
        var index = InputComponentsLookup.InputTouchDataListener;
        var component = CreateComponent<InputTouchDataListenerComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveInputTouchDataListener() {
        RemoveComponent(InputComponentsLookup.InputTouchDataListener);
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

    static Entitas.IMatcher<InputEntity> _matcherInputTouchDataListener;

    public static Entitas.IMatcher<InputEntity> InputTouchDataListener {
        get {
            if (_matcherInputTouchDataListener == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.InputTouchDataListener);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherInputTouchDataListener = matcher;
            }

            return _matcherInputTouchDataListener;
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

    public void AddInputTouchDataListener(IInputTouchDataListener value) {
        var listeners = hasInputTouchDataListener
            ? inputTouchDataListener.value
            : new System.Collections.Generic.List<IInputTouchDataListener>();
        listeners.Add(value);
        ReplaceInputTouchDataListener(listeners);
    }

    public void RemoveInputTouchDataListener(IInputTouchDataListener value, bool removeComponentWhenEmpty = true) {
        var listeners = inputTouchDataListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveInputTouchDataListener();
        } else {
            ReplaceInputTouchDataListener(listeners);
        }
    }
}
