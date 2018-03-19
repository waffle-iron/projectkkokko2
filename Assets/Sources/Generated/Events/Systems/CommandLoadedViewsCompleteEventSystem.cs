//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class CommandLoadedViewsCompleteEventSystem : Entitas.ReactiveSystem<CommandEntity> {

    readonly Entitas.IGroup<CommandEntity> _listeners;

    public CommandLoadedViewsCompleteEventSystem(Contexts contexts) : base(contexts.command) {
        _listeners = contexts.command.GetGroup(CommandMatcher.CommandLoadedViewsCompleteListener);
    }

    protected override Entitas.ICollector<CommandEntity> GetTrigger(Entitas.IContext<CommandEntity> context) {
        return Entitas.CollectorContextExtension.CreateCollector(
            context, Entitas.TriggerOnEventMatcherExtension.Added(CommandMatcher.LoadedViewsComplete)
        );
    }

    protected override bool Filter(CommandEntity entity) {
        return entity.isLoadedViewsComplete;
    }

    protected override void Execute(System.Collections.Generic.List<CommandEntity> entities) {
        foreach (var e in entities) {
            
            foreach (var listenerEntity in _listeners) {
                foreach (var listener in listenerEntity.commandLoadedViewsCompleteListener.value) {
                    listener.OnLoadedViewsComplete(e);
                }
            }
        }
    }
}
