//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public GameLoadedViewsCompleteRemovedListenerComponent gameLoadedViewsCompleteRemovedListener { get { return (GameLoadedViewsCompleteRemovedListenerComponent)GetComponent(GameComponentsLookup.GameLoadedViewsCompleteRemovedListener); } }
    public bool hasGameLoadedViewsCompleteRemovedListener { get { return HasComponent(GameComponentsLookup.GameLoadedViewsCompleteRemovedListener); } }

    public void AddGameLoadedViewsCompleteRemovedListener(System.Collections.Generic.List<IGameLoadedViewsCompleteRemovedListener> newValue) {
        var index = GameComponentsLookup.GameLoadedViewsCompleteRemovedListener;
        var component = CreateComponent<GameLoadedViewsCompleteRemovedListenerComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceGameLoadedViewsCompleteRemovedListener(System.Collections.Generic.List<IGameLoadedViewsCompleteRemovedListener> newValue) {
        var index = GameComponentsLookup.GameLoadedViewsCompleteRemovedListener;
        var component = CreateComponent<GameLoadedViewsCompleteRemovedListenerComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveGameLoadedViewsCompleteRemovedListener() {
        RemoveComponent(GameComponentsLookup.GameLoadedViewsCompleteRemovedListener);
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

    static Entitas.IMatcher<GameEntity> _matcherGameLoadedViewsCompleteRemovedListener;

    public static Entitas.IMatcher<GameEntity> GameLoadedViewsCompleteRemovedListener {
        get {
            if (_matcherGameLoadedViewsCompleteRemovedListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.GameLoadedViewsCompleteRemovedListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherGameLoadedViewsCompleteRemovedListener = matcher;
            }

            return _matcherGameLoadedViewsCompleteRemovedListener;
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

    public void AddGameLoadedViewsCompleteRemovedListener(IGameLoadedViewsCompleteRemovedListener value) {
        var listeners = hasGameLoadedViewsCompleteRemovedListener
            ? gameLoadedViewsCompleteRemovedListener.value
            : new System.Collections.Generic.List<IGameLoadedViewsCompleteRemovedListener>();
        listeners.Add(value);
        ReplaceGameLoadedViewsCompleteRemovedListener(listeners);
    }

    public void RemoveGameLoadedViewsCompleteRemovedListener(IGameLoadedViewsCompleteRemovedListener value, bool removeComponentWhenEmpty = true) {
        var listeners = gameLoadedViewsCompleteRemovedListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveGameLoadedViewsCompleteRemovedListener();
        } else {
            ReplaceGameLoadedViewsCompleteRemovedListener(listeners);
        }
    }
}
