//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiInterfaceGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial interface IAffordEntity {

    AffordComponent afford { get; }
    bool hasAfford { get; }

    void AddAfford(bool newState);
    void ReplaceAfford(bool newState);
    void RemoveAfford();
}
