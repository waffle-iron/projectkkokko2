//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class CommandActiveDialogRemovedEventSystem : Entitas.ReactiveSystem<CommandEntity> {

    readonly Entitas.IGroup<CommandEntity> _listeners;

    public CommandActiveDialogRemovedEventSystem(Contexts contexts) : base(contexts.command) {
        _listeners = contexts.command.GetGroup(CommandMatcher.CommandActiveDialogRemovedListener);
    }

    protected override Entitas.ICollector<CommandEntity> GetTrigger(Entitas.IContext<CommandEntity> context) {
        return Entitas.CollectorContextExtension.CreateCollector(
            context, Entitas.TriggerOnEventMatcherExtension.Removed(CommandMatcher.ActiveDialog)
        );
    }

    protected override bool Filter(CommandEntity entity) {
        return !entity.hasActiveDialog;
    }

    protected override void Execute(System.Collections.Generic.List<CommandEntity> entities) {
        foreach (var e in entities) {
            
            foreach (var listenerEntity in _listeners) {
                foreach (var listener in listenerEntity.commandActiveDialogRemovedListener.value) {
                    listener.OnActiveDialogRemoved(e);
                }
            }
        }
    }
}
