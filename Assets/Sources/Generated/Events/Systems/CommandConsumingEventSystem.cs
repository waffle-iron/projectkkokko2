//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class CommandConsumingEventSystem : Entitas.ReactiveSystem<CommandEntity> {

    public CommandConsumingEventSystem(Contexts contexts) : base(contexts.command) {
    }

    protected override Entitas.ICollector<CommandEntity> GetTrigger(Entitas.IContext<CommandEntity> context) {
        return Entitas.CollectorContextExtension.CreateCollector(
            context, Entitas.TriggerOnEventMatcherExtension.Added(CommandMatcher.Consuming)
        );
    }

    protected override bool Filter(CommandEntity entity) {
        return entity.hasConsuming && entity.hasCommandConsumingListener;
    }

    protected override void Execute(System.Collections.Generic.List<CommandEntity> entities) {
        foreach (var e in entities) {
            var component = e.consuming;
            foreach (var listener in e.commandConsumingListener.value) {
                listener.OnConsuming(e, component.consumerID, component.foodID);
            }
        }
    }
}
