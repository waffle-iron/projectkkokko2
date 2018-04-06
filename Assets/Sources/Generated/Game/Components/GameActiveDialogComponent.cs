//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity activeDialogEntity { get { return GetGroup(GameMatcher.ActiveDialog).GetSingleEntity(); } }
    public ActiveDialogComponent activeDialog { get { return activeDialogEntity.activeDialog; } }
    public bool hasActiveDialog { get { return activeDialogEntity != null; } }

    public GameEntity SetActiveDialog(string newId) {
        if (hasActiveDialog) {
            throw new Entitas.EntitasException("Could not set ActiveDialog!\n" + this + " already has an entity with ActiveDialogComponent!",
                "You should check if the context already has a activeDialogEntity before setting it or use context.ReplaceActiveDialog().");
        }
        var entity = CreateEntity();
        entity.AddActiveDialog(newId);
        return entity;
    }

    public void ReplaceActiveDialog(string newId) {
        var entity = activeDialogEntity;
        if (entity == null) {
            entity = SetActiveDialog(newId);
        } else {
            entity.ReplaceActiveDialog(newId);
        }
    }

    public void RemoveActiveDialog() {
        activeDialogEntity.Destroy();
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
public partial class GameEntity {

    public ActiveDialogComponent activeDialog { get { return (ActiveDialogComponent)GetComponent(GameComponentsLookup.ActiveDialog); } }
    public bool hasActiveDialog { get { return HasComponent(GameComponentsLookup.ActiveDialog); } }

    public void AddActiveDialog(string newId) {
        var index = GameComponentsLookup.ActiveDialog;
        var component = CreateComponent<ActiveDialogComponent>(index);
        component.id = newId;
        AddComponent(index, component);
    }

    public void ReplaceActiveDialog(string newId) {
        var index = GameComponentsLookup.ActiveDialog;
        var component = CreateComponent<ActiveDialogComponent>(index);
        component.id = newId;
        ReplaceComponent(index, component);
    }

    public void RemoveActiveDialog() {
        RemoveComponent(GameComponentsLookup.ActiveDialog);
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
public partial class GameEntity : IActiveDialogEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherActiveDialog;

    public static Entitas.IMatcher<GameEntity> ActiveDialog {
        get {
            if (_matcherActiveDialog == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ActiveDialog);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherActiveDialog = matcher;
            }

            return _matcherActiveDialog;
        }
    }
}
