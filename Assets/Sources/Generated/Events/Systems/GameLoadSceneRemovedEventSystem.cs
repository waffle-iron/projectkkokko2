//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class GameLoadSceneRemovedEventSystem : Entitas.ReactiveSystem<GameEntity> {

    public GameLoadSceneRemovedEventSystem(Contexts contexts) : base(contexts.game) {
    }

    protected override Entitas.ICollector<GameEntity> GetTrigger(Entitas.IContext<GameEntity> context) {
        return Entitas.CollectorContextExtension.CreateCollector(
            context, Entitas.TriggerOnEventMatcherExtension.Removed(GameMatcher.LoadScene)
        );
    }

    protected override bool Filter(GameEntity entity) {
        return !entity.hasLoadScene && entity.hasGameLoadSceneRemovedListener;
    }

    protected override void Execute(System.Collections.Generic.List<GameEntity> entities) {
        foreach (var e in entities) {
            
            foreach (var listener in e.gameLoadSceneRemovedListener.value) {
                listener.OnLoadSceneRemoved(e);
            }
        }
    }
}
