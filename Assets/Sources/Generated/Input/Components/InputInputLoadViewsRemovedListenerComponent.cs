//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    public InputLoadViewsRemovedListenerComponent inputLoadViewsRemovedListener { get { return (InputLoadViewsRemovedListenerComponent)GetComponent(InputComponentsLookup.InputLoadViewsRemovedListener); } }
    public bool hasInputLoadViewsRemovedListener { get { return HasComponent(InputComponentsLookup.InputLoadViewsRemovedListener); } }

    public void AddInputLoadViewsRemovedListener(System.Collections.Generic.List<IInputLoadViewsRemovedListener> newValue) {
        var index = InputComponentsLookup.InputLoadViewsRemovedListener;
        var component = CreateComponent<InputLoadViewsRemovedListenerComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceInputLoadViewsRemovedListener(System.Collections.Generic.List<IInputLoadViewsRemovedListener> newValue) {
        var index = InputComponentsLookup.InputLoadViewsRemovedListener;
        var component = CreateComponent<InputLoadViewsRemovedListenerComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveInputLoadViewsRemovedListener() {
        RemoveComponent(InputComponentsLookup.InputLoadViewsRemovedListener);
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

    static Entitas.IMatcher<InputEntity> _matcherInputLoadViewsRemovedListener;

    public static Entitas.IMatcher<InputEntity> InputLoadViewsRemovedListener {
        get {
            if (_matcherInputLoadViewsRemovedListener == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.InputLoadViewsRemovedListener);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherInputLoadViewsRemovedListener = matcher;
            }

            return _matcherInputLoadViewsRemovedListener;
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

    public void AddInputLoadViewsRemovedListener(IInputLoadViewsRemovedListener value) {
        var listeners = hasInputLoadViewsRemovedListener
            ? inputLoadViewsRemovedListener.value
            : new System.Collections.Generic.List<IInputLoadViewsRemovedListener>();
        listeners.Add(value);
        ReplaceInputLoadViewsRemovedListener(listeners);
    }

    public void RemoveInputLoadViewsRemovedListener(IInputLoadViewsRemovedListener value, bool removeComponentWhenEmpty = true) {
        var listeners = inputLoadViewsRemovedListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveInputLoadViewsRemovedListener();
        } else {
            ReplaceInputLoadViewsRemovedListener(listeners);
        }
    }
}
