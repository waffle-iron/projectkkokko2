//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiInterfaceGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial interface ISaveVariantEntity {

    SaveVariantComponent saveVariant { get; }
    bool hasSaveVariant { get; }

    void AddSaveVariant(CodeStage.AntiCheat.ObscuredTypes.ObscuredString newSuffix);
    void ReplaceSaveVariant(CodeStage.AntiCheat.ObscuredTypes.ObscuredString newSuffix);
    void RemoveSaveVariant();
}
