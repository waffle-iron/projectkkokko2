//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class ViewEventSystem : Entitas.ReactiveSystem<GameEntity> {

    public ViewEventSystem(Contexts contexts) : base(contexts.game) {
    }

    protected override Entitas.ICollector<GameEntity> GetTrigger(Entitas.IContext<GameEntity> context) {
        return Entitas.CollectorContextExtension.CreateCollector(
            context, Entitas.TriggerOnEventMatcherExtension.Added(GameMatcher.View)
        );
    }

    protected override bool Filter(GameEntity entity) {
        return entity.hasView && entity.hasViewListener;
    }

    protected override void Execute(System.Collections.Generic.List<GameEntity> entities) {
        foreach (var e in entities) {
            var component = e.view;
            foreach (var listener in e.viewListener.value) {
                listener.OnView(e, component.names, component.reloadOnSceneChange);
            }
        }
    }
}
