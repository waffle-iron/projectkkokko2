//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class CommandEntity {

    public MaxAmountComponent maxAmount { get { return (MaxAmountComponent)GetComponent(CommandComponentsLookup.MaxAmount); } }
    public bool hasMaxAmount { get { return HasComponent(CommandComponentsLookup.MaxAmount); } }

    public void AddMaxAmount(CodeStage.AntiCheat.ObscuredTypes.ObscuredInt newValue) {
        var index = CommandComponentsLookup.MaxAmount;
        var component = CreateComponent<MaxAmountComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceMaxAmount(CodeStage.AntiCheat.ObscuredTypes.ObscuredInt newValue) {
        var index = CommandComponentsLookup.MaxAmount;
        var component = CreateComponent<MaxAmountComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveMaxAmount() {
        RemoveComponent(CommandComponentsLookup.MaxAmount);
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
public partial class CommandEntity : IMaxAmountEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class CommandMatcher {

    static Entitas.IMatcher<CommandEntity> _matcherMaxAmount;

    public static Entitas.IMatcher<CommandEntity> MaxAmount {
        get {
            if (_matcherMaxAmount == null) {
                var matcher = (Entitas.Matcher<CommandEntity>)Entitas.Matcher<CommandEntity>.AllOf(CommandComponentsLookup.MaxAmount);
                matcher.componentNames = CommandComponentsLookup.componentNames;
                _matcherMaxAmount = matcher;
            }

            return _matcherMaxAmount;
        }
    }
}
