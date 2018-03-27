//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class InputFoodEventSystem : Entitas.ReactiveSystem<InputEntity> {

    public InputFoodEventSystem(Contexts contexts) : base(contexts.input) {
    }

    protected override Entitas.ICollector<InputEntity> GetTrigger(Entitas.IContext<InputEntity> context) {
        return Entitas.CollectorContextExtension.CreateCollector(
            context, Entitas.TriggerOnEventMatcherExtension.Added(InputMatcher.Food)
        );
    }

    protected override bool Filter(InputEntity entity) {
        return entity.hasFood && entity.hasInputFoodListener;
    }

    protected override void Execute(System.Collections.Generic.List<InputEntity> entities) {
        foreach (var e in entities) {
            var component = e.food;
            foreach (var listener in e.inputFoodListener.value) {
                listener.OnFood(e, component.id, component.recovery);
            }
        }
    }
}
