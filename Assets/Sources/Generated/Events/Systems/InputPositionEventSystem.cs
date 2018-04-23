//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class InputPositionEventSystem : Entitas.ReactiveSystem<InputEntity> {

    public InputPositionEventSystem(Contexts contexts) : base(contexts.input) {
    }

    protected override Entitas.ICollector<InputEntity> GetTrigger(Entitas.IContext<InputEntity> context) {
        return Entitas.CollectorContextExtension.CreateCollector(
            context, Entitas.TriggerOnEventMatcherExtension.Added(InputMatcher.Position)
        );
    }

    protected override bool Filter(InputEntity entity) {
        return entity.hasPosition && entity.hasInputPositionListener;
    }

    protected override void Execute(System.Collections.Generic.List<InputEntity> entities) {
        foreach (var e in entities) {
            var component = e.position;
            foreach (var listener in e.inputPositionListener.value) {
                listener.OnPosition(e, component.current);
            }
        }
    }
}
