//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public GameLoadSceneRemovedListenerComponent gameLoadSceneRemovedListener { get { return (GameLoadSceneRemovedListenerComponent)GetComponent(GameComponentsLookup.GameLoadSceneRemovedListener); } }
    public bool hasGameLoadSceneRemovedListener { get { return HasComponent(GameComponentsLookup.GameLoadSceneRemovedListener); } }

    public void AddGameLoadSceneRemovedListener(System.Collections.Generic.List<IGameLoadSceneRemovedListener> newValue) {
        var index = GameComponentsLookup.GameLoadSceneRemovedListener;
        var component = CreateComponent<GameLoadSceneRemovedListenerComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceGameLoadSceneRemovedListener(System.Collections.Generic.List<IGameLoadSceneRemovedListener> newValue) {
        var index = GameComponentsLookup.GameLoadSceneRemovedListener;
        var component = CreateComponent<GameLoadSceneRemovedListenerComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveGameLoadSceneRemovedListener() {
        RemoveComponent(GameComponentsLookup.GameLoadSceneRemovedListener);
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

    static Entitas.IMatcher<GameEntity> _matcherGameLoadSceneRemovedListener;

    public static Entitas.IMatcher<GameEntity> GameLoadSceneRemovedListener {
        get {
            if (_matcherGameLoadSceneRemovedListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.GameLoadSceneRemovedListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherGameLoadSceneRemovedListener = matcher;
            }

            return _matcherGameLoadSceneRemovedListener;
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

    public void AddGameLoadSceneRemovedListener(IGameLoadSceneRemovedListener value) {
        var listeners = hasGameLoadSceneRemovedListener
            ? gameLoadSceneRemovedListener.value
            : new System.Collections.Generic.List<IGameLoadSceneRemovedListener>();
        listeners.Add(value);
        ReplaceGameLoadSceneRemovedListener(listeners);
    }

    public void RemoveGameLoadSceneRemovedListener(IGameLoadSceneRemovedListener value, bool removeComponentWhenEmpty = true) {
        var listeners = gameLoadSceneRemovedListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveGameLoadSceneRemovedListener();
        } else {
            ReplaceGameLoadSceneRemovedListener(listeners);
        }
    }
}
