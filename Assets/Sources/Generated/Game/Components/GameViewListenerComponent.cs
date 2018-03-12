//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public ViewListenerComponent viewListener { get { return (ViewListenerComponent)GetComponent(GameComponentsLookup.ViewListener); } }
    public bool hasViewListener { get { return HasComponent(GameComponentsLookup.ViewListener); } }

    public void AddViewListener(System.Collections.Generic.List<IViewListener> newValue) {
        var index = GameComponentsLookup.ViewListener;
        var component = CreateComponent<ViewListenerComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceViewListener(System.Collections.Generic.List<IViewListener> newValue) {
        var index = GameComponentsLookup.ViewListener;
        var component = CreateComponent<ViewListenerComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveViewListener() {
        RemoveComponent(GameComponentsLookup.ViewListener);
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
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherViewListener;

    public static Entitas.IMatcher<GameEntity> ViewListener {
        get {
            if (_matcherViewListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ViewListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherViewListener = matcher;
            }

            return _matcherViewListener;
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
public partial class GameEntity {

    public void AddViewListener(IViewListener value) {
        var listeners = hasViewListener
            ? viewListener.value
            : new System.Collections.Generic.List<IViewListener>();
        listeners.Add(value);
        ReplaceViewListener(listeners);
    }

    public void RemoveViewListener(IViewListener value, bool removeComponentWhenEmpty = true) {
        var listeners = viewListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveViewListener();
        } else {
            ReplaceViewListener(listeners);
        }
    }
}
