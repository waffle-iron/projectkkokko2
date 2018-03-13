//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class CommandEntity {

    static readonly AnimatingComponent animatingComponent = new AnimatingComponent();

    public bool isAnimating {
        get { return HasComponent(CommandComponentsLookup.Animating); }
        set {
            if (value != isAnimating) {
                var index = CommandComponentsLookup.Animating;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : animatingComponent;

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
public partial class CommandEntity : IAnimatingEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class CommandMatcher {

    static Entitas.IMatcher<CommandEntity> _matcherAnimating;

    public static Entitas.IMatcher<CommandEntity> Animating {
        get {
            if (_matcherAnimating == null) {
                var matcher = (Entitas.Matcher<CommandEntity>)Entitas.Matcher<CommandEntity>.AllOf(CommandComponentsLookup.Animating);
                matcher.componentNames = CommandComponentsLookup.componentNames;
                _matcherAnimating = matcher;
            }

            return _matcherAnimating;
        }
    }
}
