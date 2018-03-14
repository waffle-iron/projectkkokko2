//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class CommandContext {

    public CommandEntity walletEntity { get { return GetGroup(CommandMatcher.Wallet).GetSingleEntity(); } }
    public WalletComponent wallet { get { return walletEntity.wallet; } }
    public bool hasWallet { get { return walletEntity != null; } }

    public CommandEntity SetWallet(int newAmount) {
        if (hasWallet) {
            throw new Entitas.EntitasException("Could not set Wallet!\n" + this + " already has an entity with WalletComponent!",
                "You should check if the context already has a walletEntity before setting it or use context.ReplaceWallet().");
        }
        var entity = CreateEntity();
        entity.AddWallet(newAmount);
        return entity;
    }

    public void ReplaceWallet(int newAmount) {
        var entity = walletEntity;
        if (entity == null) {
            entity = SetWallet(newAmount);
        } else {
            entity.ReplaceWallet(newAmount);
        }
    }

    public void RemoveWallet() {
        walletEntity.Destroy();
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

    public WalletComponent wallet { get { return (WalletComponent)GetComponent(CommandComponentsLookup.Wallet); } }
    public bool hasWallet { get { return HasComponent(CommandComponentsLookup.Wallet); } }

    public void AddWallet(int newAmount) {
        var index = CommandComponentsLookup.Wallet;
        var component = CreateComponent<WalletComponent>(index);
        component.amount = newAmount;
        AddComponent(index, component);
    }

    public void ReplaceWallet(int newAmount) {
        var index = CommandComponentsLookup.Wallet;
        var component = CreateComponent<WalletComponent>(index);
        component.amount = newAmount;
        ReplaceComponent(index, component);
    }

    public void RemoveWallet() {
        RemoveComponent(CommandComponentsLookup.Wallet);
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
public partial class CommandEntity : IWalletEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class CommandMatcher {

    static Entitas.IMatcher<CommandEntity> _matcherWallet;

    public static Entitas.IMatcher<CommandEntity> Wallet {
        get {
            if (_matcherWallet == null) {
                var matcher = (Entitas.Matcher<CommandEntity>)Entitas.Matcher<CommandEntity>.AllOf(CommandComponentsLookup.Wallet);
                matcher.componentNames = CommandComponentsLookup.componentNames;
                _matcherWallet = matcher;
            }

            return _matcherWallet;
        }
    }
}
