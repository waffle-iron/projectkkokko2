//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class CommandEntity {

    public ChangeScoreComponent changeScore { get { return (ChangeScoreComponent)GetComponent(CommandComponentsLookup.ChangeScore); } }
    public bool hasChangeScore { get { return HasComponent(CommandComponentsLookup.ChangeScore); } }

    public void AddChangeScore(int newValue, OperationType newOperation) {
        var index = CommandComponentsLookup.ChangeScore;
        var component = CreateComponent<ChangeScoreComponent>(index);
        component.value = newValue;
        component.operation = newOperation;
        AddComponent(index, component);
    }

    public void ReplaceChangeScore(int newValue, OperationType newOperation) {
        var index = CommandComponentsLookup.ChangeScore;
        var component = CreateComponent<ChangeScoreComponent>(index);
        component.value = newValue;
        component.operation = newOperation;
        ReplaceComponent(index, component);
    }

    public void RemoveChangeScore() {
        RemoveComponent(CommandComponentsLookup.ChangeScore);
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
public partial class CommandEntity : IChangeScoreEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class CommandMatcher {

    static Entitas.IMatcher<CommandEntity> _matcherChangeScore;

    public static Entitas.IMatcher<CommandEntity> ChangeScore {
        get {
            if (_matcherChangeScore == null) {
                var matcher = (Entitas.Matcher<CommandEntity>)Entitas.Matcher<CommandEntity>.AllOf(CommandComponentsLookup.ChangeScore);
                matcher.componentNames = CommandComponentsLookup.componentNames;
                _matcherChangeScore = matcher;
            }

            return _matcherChangeScore;
        }
    }
}
