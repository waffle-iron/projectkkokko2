//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class CommandTargetMoveEventSystem : Entitas.ReactiveSystem<CommandEntity> {

    public CommandTargetMoveEventSystem(Contexts contexts) : base(contexts.command) {
    }

    protected override Entitas.ICollector<CommandEntity> GetTrigger(Entitas.IContext<CommandEntity> context) {
        return Entitas.CollectorContextExtension.CreateCollector(
            context, Entitas.TriggerOnEventMatcherExtension.Added(CommandMatcher.TargetMove)
        );
    }

    protected override bool Filter(CommandEntity entity) {
        return entity.hasTargetMove && entity.hasCommandTargetMoveListener;
    }

    protected override void Execute(System.Collections.Generic.List<CommandEntity> entities) {
        foreach (var e in entities) {
            var component = e.targetMove;
            foreach (var listener in e.commandTargetMoveListener.value) {
                listener.OnTargetMove(e, component.position);
            }
        }
    }
}
