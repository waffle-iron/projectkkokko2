//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class GameNeedEventSystem : Entitas.ReactiveSystem<GameEntity> {

    public GameNeedEventSystem(Contexts contexts) : base(contexts.game) {
    }

    protected override Entitas.ICollector<GameEntity> GetTrigger(Entitas.IContext<GameEntity> context) {
        return Entitas.CollectorContextExtension.CreateCollector(
            context, Entitas.TriggerOnEventMatcherExtension.Added(GameMatcher.Need)
        );
    }

    protected override bool Filter(GameEntity entity) {
        return entity.hasNeed && entity.hasGameNeedListener;
    }

    protected override void Execute(System.Collections.Generic.List<GameEntity> entities) {
        foreach (var e in entities) {
            var component = e.need;
            foreach (var listener in e.gameNeedListener.value) {
                listener.OnNeed(e, component.type, component.action);
            }
        }
    }
}
