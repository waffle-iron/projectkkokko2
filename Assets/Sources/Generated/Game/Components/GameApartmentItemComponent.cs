//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public ApartmentItemComponent apartmentItem { get { return (ApartmentItemComponent)GetComponent(GameComponentsLookup.ApartmentItem); } }
    public bool hasApartmentItem { get { return HasComponent(GameComponentsLookup.ApartmentItem); } }

    public void AddApartmentItem(ApartmentItemType newType, string newId) {
        var index = GameComponentsLookup.ApartmentItem;
        var component = CreateComponent<ApartmentItemComponent>(index);
        component.type = newType;
        component.id = newId;
        AddComponent(index, component);
    }

    public void ReplaceApartmentItem(ApartmentItemType newType, string newId) {
        var index = GameComponentsLookup.ApartmentItem;
        var component = CreateComponent<ApartmentItemComponent>(index);
        component.type = newType;
        component.id = newId;
        ReplaceComponent(index, component);
    }

    public void RemoveApartmentItem() {
        RemoveComponent(GameComponentsLookup.ApartmentItem);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherApartmentItem;

    public static Entitas.IMatcher<GameEntity> ApartmentItem {
        get {
            if (_matcherApartmentItem == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ApartmentItem);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherApartmentItem = matcher;
            }

            return _matcherApartmentItem;
        }
    }
}
