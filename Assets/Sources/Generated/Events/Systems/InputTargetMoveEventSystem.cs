//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class InputTargetMoveEventSystem : Entitas.ReactiveSystem<InputEntity> {

    public InputTargetMoveEventSystem(Contexts contexts) : base(contexts.input) {
    }

    protected override Entitas.ICollector<InputEntity> GetTrigger(Entitas.IContext<InputEntity> context) {
        return Entitas.CollectorContextExtension.CreateCollector(
            context, Entitas.TriggerOnEventMatcherExtension.Added(InputMatcher.TargetMove)
        );
    }

    protected override bool Filter(InputEntity entity) {
        return entity.hasTargetMove && entity.hasInputTargetMoveListener;
    }

    protected override void Execute(System.Collections.Generic.List<InputEntity> entities) {
        foreach (var e in entities) {
            var component = e.targetMove;
            foreach (var listener in e.inputTargetMoveListener.value) {
                listener.OnTargetMove(e, component.position);
            }
        }
    }
}
