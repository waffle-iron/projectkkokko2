//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public PriceComponent price { get { return (PriceComponent)GetComponent(GameComponentsLookup.Price); } }
    public bool hasPrice { get { return HasComponent(GameComponentsLookup.Price); } }

    public void AddPrice(CodeStage.AntiCheat.ObscuredTypes.ObscuredInt newAmount) {
        var index = GameComponentsLookup.Price;
        var component = CreateComponent<PriceComponent>(index);
        component.amount = newAmount;
        AddComponent(index, component);
    }

    public void ReplacePrice(CodeStage.AntiCheat.ObscuredTypes.ObscuredInt newAmount) {
        var index = GameComponentsLookup.Price;
        var component = CreateComponent<PriceComponent>(index);
        component.amount = newAmount;
        ReplaceComponent(index, component);
    }

    public void RemovePrice() {
        RemoveComponent(GameComponentsLookup.Price);
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
public partial class GameEntity : IPriceEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherPrice;

    public static Entitas.IMatcher<GameEntity> Price {
        get {
            if (_matcherPrice == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Price);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherPrice = matcher;
            }

            return _matcherPrice;
        }
    }
}
