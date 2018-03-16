//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    public InputWalletListenerComponent inputWalletListener { get { return (InputWalletListenerComponent)GetComponent(InputComponentsLookup.InputWalletListener); } }
    public bool hasInputWalletListener { get { return HasComponent(InputComponentsLookup.InputWalletListener); } }

    public void AddInputWalletListener(System.Collections.Generic.List<IInputWalletListener> newValue) {
        var index = InputComponentsLookup.InputWalletListener;
        var component = CreateComponent<InputWalletListenerComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceInputWalletListener(System.Collections.Generic.List<IInputWalletListener> newValue) {
        var index = InputComponentsLookup.InputWalletListener;
        var component = CreateComponent<InputWalletListenerComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveInputWalletListener() {
        RemoveComponent(InputComponentsLookup.InputWalletListener);
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

    static Entitas.IMatcher<InputEntity> _matcherInputWalletListener;

    public static Entitas.IMatcher<InputEntity> InputWalletListener {
        get {
            if (_matcherInputWalletListener == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.InputWalletListener);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherInputWalletListener = matcher;
            }

            return _matcherInputWalletListener;
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

    public void AddInputWalletListener(IInputWalletListener value) {
        var listeners = hasInputWalletListener
            ? inputWalletListener.value
            : new System.Collections.Generic.List<IInputWalletListener>();
        listeners.Add(value);
        ReplaceInputWalletListener(listeners);
    }

    public void RemoveInputWalletListener(IInputWalletListener value, bool removeComponentWhenEmpty = true) {
        var listeners = inputWalletListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveInputWalletListener();
        } else {
            ReplaceInputWalletListener(listeners);
        }
    }
}
