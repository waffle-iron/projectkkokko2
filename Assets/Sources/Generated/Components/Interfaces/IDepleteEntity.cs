//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiInterfaceGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial interface IDepleteEntity {

    DepleteComponent deplete { get; }
    bool hasDeplete { get; }

    void AddDeplete(CodeStage.AntiCheat.ObscuredTypes.ObscuredInt newAmount);
    void ReplaceDeplete(CodeStage.AntiCheat.ObscuredTypes.ObscuredInt newAmount);
    void RemoveDeplete();
}
