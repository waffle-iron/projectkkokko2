//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class InputLoadedViewsCompleteRemovedEventSystem : Entitas.ReactiveSystem<InputEntity> {

    readonly Entitas.IGroup<InputEntity> _listeners;

    public InputLoadedViewsCompleteRemovedEventSystem(Contexts contexts) : base(contexts.input) {
        _listeners = contexts.input.GetGroup(InputMatcher.InputLoadedViewsCompleteRemovedListener);
    }

    protected override Entitas.ICollector<InputEntity> GetTrigger(Entitas.IContext<InputEntity> context) {
        return Entitas.CollectorContextExtension.CreateCollector(
            context, Entitas.TriggerOnEventMatcherExtension.Removed(InputMatcher.LoadedViewsComplete)
        );
    }

    protected override bool Filter(InputEntity entity) {
        return !entity.isLoadedViewsComplete;
    }

    protected override void Execute(System.Collections.Generic.List<InputEntity> entities) {
        foreach (var e in entities) {
            
            foreach (var listenerEntity in _listeners) {
                foreach (var listener in listenerEntity.inputLoadedViewsCompleteRemovedListener.value) {
                    listener.OnLoadedViewsCompleteRemoved(e);
                }
            }
        }
    }
}
