//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class GameLoadSceneEventSystem : Entitas.ReactiveSystem<GameEntity> {

    readonly Entitas.IGroup<GameEntity> _listeners;

    public GameLoadSceneEventSystem(Contexts contexts) : base(contexts.game) {
        _listeners = contexts.game.GetGroup(GameMatcher.GameLoadSceneListener);
    }

    protected override Entitas.ICollector<GameEntity> GetTrigger(Entitas.IContext<GameEntity> context) {
        return Entitas.CollectorContextExtension.CreateCollector(
            context, Entitas.TriggerOnEventMatcherExtension.Added(GameMatcher.LoadScene)
        );
    }

    protected override bool Filter(GameEntity entity) {
        return entity.hasLoadScene;
    }

    protected override void Execute(System.Collections.Generic.List<GameEntity> entities) {
        foreach (var e in entities) {
            var component = e.loadScene;
            foreach (var listenerEntity in _listeners) {
                foreach (var listener in listenerEntity.gameLoadSceneListener.value) {
                    listener.OnLoadScene(e, component.name);
                }
            }
        }
    }
}
