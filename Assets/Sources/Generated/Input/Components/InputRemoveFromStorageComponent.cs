//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    static readonly RemoveFromStorageComponent removeFromStorageComponent = new RemoveFromStorageComponent();

    public bool isRemoveFromStorage {
        get { return HasComponent(InputComponentsLookup.RemoveFromStorage); }
        set {
            if (value != isRemoveFromStorage) {
                var index = InputComponentsLookup.RemoveFromStorage;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : removeFromStorageComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
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
public partial class InputEntity : IRemoveFromStorageEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherRemoveFromStorage;

    public static Entitas.IMatcher<InputEntity> RemoveFromStorage {
        get {
            if (_matcherRemoveFromStorage == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.RemoveFromStorage);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherRemoveFromStorage = matcher;
            }

            return _matcherRemoveFromStorage;
        }
    }
}
