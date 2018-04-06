//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public DeactivateDialogComponent deactivateDialog { get { return (DeactivateDialogComponent)GetComponent(GameComponentsLookup.DeactivateDialog); } }
    public bool hasDeactivateDialog { get { return HasComponent(GameComponentsLookup.DeactivateDialog); } }

    public void AddDeactivateDialog(string newId) {
        var index = GameComponentsLookup.DeactivateDialog;
        var component = CreateComponent<DeactivateDialogComponent>(index);
        component.id = newId;
        AddComponent(index, component);
    }

    public void ReplaceDeactivateDialog(string newId) {
        var index = GameComponentsLookup.DeactivateDialog;
        var component = CreateComponent<DeactivateDialogComponent>(index);
        component.id = newId;
        ReplaceComponent(index, component);
    }

    public void RemoveDeactivateDialog() {
        RemoveComponent(GameComponentsLookup.DeactivateDialog);
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
public partial class GameEntity : IDeactivateDialogEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherDeactivateDialog;

    public static Entitas.IMatcher<GameEntity> DeactivateDialog {
        get {
            if (_matcherDeactivateDialog == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.DeactivateDialog);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherDeactivateDialog = matcher;
            }

            return _matcherDeactivateDialog;
        }
    }
}
