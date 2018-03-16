//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class InputAffordEventSystem : Entitas.ReactiveSystem<InputEntity> {

    public InputAffordEventSystem(Contexts contexts) : base(contexts.input) {
    }

    protected override Entitas.ICollector<InputEntity> GetTrigger(Entitas.IContext<InputEntity> context) {
        return Entitas.CollectorContextExtension.CreateCollector(
            context, Entitas.TriggerOnEventMatcherExtension.Added(InputMatcher.Afford)
        );
    }

    protected override bool Filter(InputEntity entity) {
        return entity.hasAfford && entity.hasInputAffordListener;
    }

    protected override void Execute(System.Collections.Generic.List<InputEntity> entities) {
        foreach (var e in entities) {
            var component = e.afford;
            foreach (var listener in e.inputAffordListener.value) {
                listener.OnAfford(e, component.state);
            }
        }
    }
}
