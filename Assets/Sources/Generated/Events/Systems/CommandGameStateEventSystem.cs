//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class CommandGameStateEventSystem : Entitas.ReactiveSystem<CommandEntity> {

    readonly Entitas.IGroup<CommandEntity> _listeners;

    public CommandGameStateEventSystem(Contexts contexts) : base(contexts.command) {
        _listeners = contexts.command.GetGroup(CommandMatcher.CommandGameStateListener);
    }

    protected override Entitas.ICollector<CommandEntity> GetTrigger(Entitas.IContext<CommandEntity> context) {
        return Entitas.CollectorContextExtension.CreateCollector(
            context, Entitas.TriggerOnEventMatcherExtension.Added(CommandMatcher.GameState)
        );
    }

    protected override bool Filter(CommandEntity entity) {
        return entity.hasGameState;
    }

    protected override void Execute(System.Collections.Generic.List<CommandEntity> entities) {
        foreach (var e in entities) {
            var component = e.gameState;
            foreach (var listenerEntity in _listeners) {
                foreach (var listener in listenerEntity.commandGameStateListener.value) {
                    listener.OnGameState(e, component.current);
                }
            }
        }
    }
}
