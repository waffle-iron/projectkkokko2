//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class InputActiveDialogEventSystem : Entitas.ReactiveSystem<InputEntity> {

    readonly Entitas.IGroup<InputEntity> _listeners;

    public InputActiveDialogEventSystem(Contexts contexts) : base(contexts.input) {
        _listeners = contexts.input.GetGroup(InputMatcher.InputActiveDialogListener);
    }

    protected override Entitas.ICollector<InputEntity> GetTrigger(Entitas.IContext<InputEntity> context) {
        return Entitas.CollectorContextExtension.CreateCollector(
            context, Entitas.TriggerOnEventMatcherExtension.Added(InputMatcher.ActiveDialog)
        );
    }

    protected override bool Filter(InputEntity entity) {
        return entity.hasActiveDialog;
    }

    protected override void Execute(System.Collections.Generic.List<InputEntity> entities) {
        foreach (var e in entities) {
            var component = e.activeDialog;
            foreach (var listenerEntity in _listeners) {
                foreach (var listener in listenerEntity.inputActiveDialogListener.value) {
                    listener.OnActiveDialog(e, component.id);
                }
            }
        }
    }
}
