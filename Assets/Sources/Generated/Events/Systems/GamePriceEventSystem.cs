//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class GamePriceEventSystem : Entitas.ReactiveSystem<GameEntity> {

    public GamePriceEventSystem(Contexts contexts) : base(contexts.game) {
    }

    protected override Entitas.ICollector<GameEntity> GetTrigger(Entitas.IContext<GameEntity> context) {
        return Entitas.CollectorContextExtension.CreateCollector(
            context, Entitas.TriggerOnEventMatcherExtension.Added(GameMatcher.Price)
        );
    }

    protected override bool Filter(GameEntity entity) {
        return entity.hasPrice && entity.hasGamePriceListener;
    }

    protected override void Execute(System.Collections.Generic.List<GameEntity> entities) {
        foreach (var e in entities) {
            var component = e.price;
            foreach (var listener in e.gamePriceListener.value) {
                listener.OnPrice(e, component.amount);
            }
        }
    }
}
