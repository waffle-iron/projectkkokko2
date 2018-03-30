//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class GameTargetMoveEventSystem : Entitas.ReactiveSystem<GameEntity> {

    public GameTargetMoveEventSystem(Contexts contexts) : base(contexts.game) {
    }

    protected override Entitas.ICollector<GameEntity> GetTrigger(Entitas.IContext<GameEntity> context) {
        return Entitas.CollectorContextExtension.CreateCollector(
            context, Entitas.TriggerOnEventMatcherExtension.Added(GameMatcher.TargetMove)
        );
    }

    protected override bool Filter(GameEntity entity) {
        return entity.hasTargetMove && entity.hasGameTargetMoveListener;
    }

    protected override void Execute(System.Collections.Generic.List<GameEntity> entities) {
        foreach (var e in entities) {
            var component = e.targetMove;
            foreach (var listener in e.gameTargetMoveListener.value) {
                listener.OnTargetMove(e, component.position, component.stopDistance);
            }
        }
    }
}
