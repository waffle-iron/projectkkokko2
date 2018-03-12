//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class CommandContext {

    public CommandEntity pauseEntity { get { return GetGroup(CommandMatcher.Pause).GetSingleEntity(); } }
    public PauseComponent pause { get { return pauseEntity.pause; } }
    public bool hasPause { get { return pauseEntity != null; } }

    public CommandEntity SetPause(bool newState) {
        if (hasPause) {
            throw new Entitas.EntitasException("Could not set Pause!\n" + this + " already has an entity with PauseComponent!",
                "You should check if the context already has a pauseEntity before setting it or use context.ReplacePause().");
        }
        var entity = CreateEntity();
        entity.AddPause(newState);
        return entity;
    }

    public void ReplacePause(bool newState) {
        var entity = pauseEntity;
        if (entity == null) {
            entity = SetPause(newState);
        } else {
            entity.ReplacePause(newState);
        }
    }

    public void RemovePause() {
        pauseEntity.Destroy();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class CommandEntity {

    public PauseComponent pause { get { return (PauseComponent)GetComponent(CommandComponentsLookup.Pause); } }
    public bool hasPause { get { return HasComponent(CommandComponentsLookup.Pause); } }

    public void AddPause(bool newState) {
        var index = CommandComponentsLookup.Pause;
        var component = CreateComponent<PauseComponent>(index);
        component.state = newState;
        AddComponent(index, component);
    }

    public void ReplacePause(bool newState) {
        var index = CommandComponentsLookup.Pause;
        var component = CreateComponent<PauseComponent>(index);
        component.state = newState;
        ReplaceComponent(index, component);
    }

    public void RemovePause() {
        RemoveComponent(CommandComponentsLookup.Pause);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiInterfaceGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class CommandEntity : IPauseEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class CommandMatcher {

    static Entitas.IMatcher<CommandEntity> _matcherPause;

    public static Entitas.IMatcher<CommandEntity> Pause {
        get {
            if (_matcherPause == null) {
                var matcher = (Entitas.Matcher<CommandEntity>)Entitas.Matcher<CommandEntity>.AllOf(CommandComponentsLookup.Pause);
                matcher.componentNames = CommandComponentsLookup.componentNames;
                _matcherPause = matcher;
            }

            return _matcherPause;
        }
    }
}
