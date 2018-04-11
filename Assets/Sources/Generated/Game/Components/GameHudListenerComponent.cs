//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public HudListenerComponent hudListener { get { return (HudListenerComponent)GetComponent(GameComponentsLookup.HudListener); } }
    public bool hasHudListener { get { return HasComponent(GameComponentsLookup.HudListener); } }

    public void AddHudListener(System.Collections.Generic.List<IHudListener> newValue) {
        var index = GameComponentsLookup.HudListener;
        var component = CreateComponent<HudListenerComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceHudListener(System.Collections.Generic.List<IHudListener> newValue) {
        var index = GameComponentsLookup.HudListener;
        var component = CreateComponent<HudListenerComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveHudListener() {
        RemoveComponent(GameComponentsLookup.HudListener);
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

    static Entitas.IMatcher<GameEntity> _matcherHudListener;

    public static Entitas.IMatcher<GameEntity> HudListener {
        get {
            if (_matcherHudListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.HudListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherHudListener = matcher;
            }

            return _matcherHudListener;
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

    public void AddHudListener(IHudListener value) {
        var listeners = hasHudListener
            ? hudListener.value
            : new System.Collections.Generic.List<IHudListener>();
        listeners.Add(value);
        ReplaceHudListener(listeners);
    }

    public void RemoveHudListener(IHudListener value, bool removeComponentWhenEmpty = true) {
        var listeners = hudListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveHudListener();
        } else {
            ReplaceHudListener(listeners);
        }
    }
}
