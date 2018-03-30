//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public GameRemoveFromStorageListenerComponent gameRemoveFromStorageListener { get { return (GameRemoveFromStorageListenerComponent)GetComponent(GameComponentsLookup.GameRemoveFromStorageListener); } }
    public bool hasGameRemoveFromStorageListener { get { return HasComponent(GameComponentsLookup.GameRemoveFromStorageListener); } }

    public void AddGameRemoveFromStorageListener(System.Collections.Generic.List<IGameRemoveFromStorageListener> newValue) {
        var index = GameComponentsLookup.GameRemoveFromStorageListener;
        var component = CreateComponent<GameRemoveFromStorageListenerComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceGameRemoveFromStorageListener(System.Collections.Generic.List<IGameRemoveFromStorageListener> newValue) {
        var index = GameComponentsLookup.GameRemoveFromStorageListener;
        var component = CreateComponent<GameRemoveFromStorageListenerComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveGameRemoveFromStorageListener() {
        RemoveComponent(GameComponentsLookup.GameRemoveFromStorageListener);
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

    static Entitas.IMatcher<GameEntity> _matcherGameRemoveFromStorageListener;

    public static Entitas.IMatcher<GameEntity> GameRemoveFromStorageListener {
        get {
            if (_matcherGameRemoveFromStorageListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.GameRemoveFromStorageListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherGameRemoveFromStorageListener = matcher;
            }

            return _matcherGameRemoveFromStorageListener;
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

    public void AddGameRemoveFromStorageListener(IGameRemoveFromStorageListener value) {
        var listeners = hasGameRemoveFromStorageListener
            ? gameRemoveFromStorageListener.value
            : new System.Collections.Generic.List<IGameRemoveFromStorageListener>();
        listeners.Add(value);
        ReplaceGameRemoveFromStorageListener(listeners);
    }

    public void RemoveGameRemoveFromStorageListener(IGameRemoveFromStorageListener value, bool removeComponentWhenEmpty = true) {
        var listeners = gameRemoveFromStorageListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveGameRemoveFromStorageListener();
        } else {
            ReplaceGameRemoveFromStorageListener(listeners);
        }
    }
}
