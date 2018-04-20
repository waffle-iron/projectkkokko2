//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class CommandOnCollisionEventSystem : Entitas.ReactiveSystem<CommandEntity> {

    public CommandOnCollisionEventSystem(Contexts contexts) : base(contexts.command) {
    }

    protected override Entitas.ICollector<CommandEntity> GetTrigger(Entitas.IContext<CommandEntity> context) {
        return Entitas.CollectorContextExtension.CreateCollector(
            context, Entitas.TriggerOnEventMatcherExtension.Added(CommandMatcher.OnCollision)
        );
    }

    protected override bool Filter(CommandEntity entity) {
        return entity.hasOnCollision && entity.hasCommandOnCollisionListener;
    }

    protected override void Execute(System.Collections.Generic.List<CommandEntity> entities) {
        foreach (var e in entities) {
            var component = e.onCollision;
            foreach (var listener in e.commandOnCollisionListener.value) {
                listener.OnOnCollision(e, component.data);
            }
        }
    }
}
