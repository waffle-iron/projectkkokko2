//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public NotificationScheduledComponent notificationScheduled { get { return (NotificationScheduledComponent)GetComponent(GameComponentsLookup.NotificationScheduled); } }
    public bool hasNotificationScheduled { get { return HasComponent(GameComponentsLookup.NotificationScheduled); } }

    public void AddNotificationScheduled(int newSeconds, int newId) {
        var index = GameComponentsLookup.NotificationScheduled;
        var component = CreateComponent<NotificationScheduledComponent>(index);
        component.seconds = newSeconds;
        component.id = newId;
        AddComponent(index, component);
    }

    public void ReplaceNotificationScheduled(int newSeconds, int newId) {
        var index = GameComponentsLookup.NotificationScheduled;
        var component = CreateComponent<NotificationScheduledComponent>(index);
        component.seconds = newSeconds;
        component.id = newId;
        ReplaceComponent(index, component);
    }

    public void RemoveNotificationScheduled() {
        RemoveComponent(GameComponentsLookup.NotificationScheduled);
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

    static Entitas.IMatcher<GameEntity> _matcherNotificationScheduled;

    public static Entitas.IMatcher<GameEntity> NotificationScheduled {
        get {
            if (_matcherNotificationScheduled == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.NotificationScheduled);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherNotificationScheduled = matcher;
            }

            return _matcherNotificationScheduled;
        }
    }
}
