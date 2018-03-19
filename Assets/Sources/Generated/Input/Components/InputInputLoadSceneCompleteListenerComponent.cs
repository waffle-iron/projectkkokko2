//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    public InputLoadSceneCompleteListenerComponent inputLoadSceneCompleteListener { get { return (InputLoadSceneCompleteListenerComponent)GetComponent(InputComponentsLookup.InputLoadSceneCompleteListener); } }
    public bool hasInputLoadSceneCompleteListener { get { return HasComponent(InputComponentsLookup.InputLoadSceneCompleteListener); } }

    public void AddInputLoadSceneCompleteListener(System.Collections.Generic.List<IInputLoadSceneCompleteListener> newValue) {
        var index = InputComponentsLookup.InputLoadSceneCompleteListener;
        var component = CreateComponent<InputLoadSceneCompleteListenerComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceInputLoadSceneCompleteListener(System.Collections.Generic.List<IInputLoadSceneCompleteListener> newValue) {
        var index = InputComponentsLookup.InputLoadSceneCompleteListener;
        var component = CreateComponent<InputLoadSceneCompleteListenerComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveInputLoadSceneCompleteListener() {
        RemoveComponent(InputComponentsLookup.InputLoadSceneCompleteListener);
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

    static Entitas.IMatcher<InputEntity> _matcherInputLoadSceneCompleteListener;

    public static Entitas.IMatcher<InputEntity> InputLoadSceneCompleteListener {
        get {
            if (_matcherInputLoadSceneCompleteListener == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.InputLoadSceneCompleteListener);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherInputLoadSceneCompleteListener = matcher;
            }

            return _matcherInputLoadSceneCompleteListener;
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

    public void AddInputLoadSceneCompleteListener(IInputLoadSceneCompleteListener value) {
        var listeners = hasInputLoadSceneCompleteListener
            ? inputLoadSceneCompleteListener.value
            : new System.Collections.Generic.List<IInputLoadSceneCompleteListener>();
        listeners.Add(value);
        ReplaceInputLoadSceneCompleteListener(listeners);
    }

    public void RemoveInputLoadSceneCompleteListener(IInputLoadSceneCompleteListener value, bool removeComponentWhenEmpty = true) {
        var listeners = inputLoadSceneCompleteListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveInputLoadSceneCompleteListener();
        } else {
            ReplaceInputLoadSceneCompleteListener(listeners);
        }
    }
}
