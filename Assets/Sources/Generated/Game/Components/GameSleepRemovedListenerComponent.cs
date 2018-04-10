//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public SleepRemovedListenerComponent sleepRemovedListener { get { return (SleepRemovedListenerComponent)GetComponent(GameComponentsLookup.SleepRemovedListener); } }
    public bool hasSleepRemovedListener { get { return HasComponent(GameComponentsLookup.SleepRemovedListener); } }

    public void AddSleepRemovedListener(System.Collections.Generic.List<ISleepRemovedListener> newValue) {
        var index = GameComponentsLookup.SleepRemovedListener;
        var component = CreateComponent<SleepRemovedListenerComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceSleepRemovedListener(System.Collections.Generic.List<ISleepRemovedListener> newValue) {
        var index = GameComponentsLookup.SleepRemovedListener;
        var component = CreateComponent<SleepRemovedListenerComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveSleepRemovedListener() {
        RemoveComponent(GameComponentsLookup.SleepRemovedListener);
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

    static Entitas.IMatcher<GameEntity> _matcherSleepRemovedListener;

    public static Entitas.IMatcher<GameEntity> SleepRemovedListener {
        get {
            if (_matcherSleepRemovedListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.SleepRemovedListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherSleepRemovedListener = matcher;
            }

            return _matcherSleepRemovedListener;
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

    public void AddSleepRemovedListener(ISleepRemovedListener value) {
        var listeners = hasSleepRemovedListener
            ? sleepRemovedListener.value
            : new System.Collections.Generic.List<ISleepRemovedListener>();
        listeners.Add(value);
        ReplaceSleepRemovedListener(listeners);
    }

    public void RemoveSleepRemovedListener(ISleepRemovedListener value, bool removeComponentWhenEmpty = true) {
        var listeners = sleepRemovedListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveSleepRemovedListener();
        } else {
            ReplaceSleepRemovedListener(listeners);
        }
    }
}
