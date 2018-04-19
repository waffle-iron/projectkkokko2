//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class ValidPlacementEventSystem : Entitas.ReactiveSystem<GameEntity> {

    public ValidPlacementEventSystem(Contexts contexts) : base(contexts.game) {
    }

    protected override Entitas.ICollector<GameEntity> GetTrigger(Entitas.IContext<GameEntity> context) {
        return Entitas.CollectorContextExtension.CreateCollector(
            context, Entitas.TriggerOnEventMatcherExtension.Added(GameMatcher.ValidPlacement)
        );
    }

    protected override bool Filter(GameEntity entity) {
        return entity.hasValidPlacement && entity.hasValidPlacementListener;
    }

    protected override void Execute(System.Collections.Generic.List<GameEntity> entities) {
        foreach (var e in entities) {
            var component = e.validPlacement;
            foreach (var listener in e.validPlacementListener.value) {
                listener.OnValidPlacement(e, component.state);
            }
        }
    }
}
