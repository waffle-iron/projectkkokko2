//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class CommandPriceEventSystem : Entitas.ReactiveSystem<CommandEntity> {

    public CommandPriceEventSystem(Contexts contexts) : base(contexts.command) {
    }

    protected override Entitas.ICollector<CommandEntity> GetTrigger(Entitas.IContext<CommandEntity> context) {
        return Entitas.CollectorContextExtension.CreateCollector(
            context, Entitas.TriggerOnEventMatcherExtension.Added(CommandMatcher.Price)
        );
    }

    protected override bool Filter(CommandEntity entity) {
        return entity.hasPrice && entity.hasCommandPriceListener;
    }

    protected override void Execute(System.Collections.Generic.List<CommandEntity> entities) {
        foreach (var e in entities) {
            var component = e.price;
            foreach (var listener in e.commandPriceListener.value) {
                listener.OnPrice(e, component.amount);
            }
        }
    }
}
