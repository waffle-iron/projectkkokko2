//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiInterfaceGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial interface ICreateEntityEntity {

    CreateEntityComponent createEntity { get; }
    bool hasCreateEntity { get; }

    void AddCreateEntity(EntityCfgID newId);
    void ReplaceCreateEntity(EntityCfgID newId);
    void RemoveCreateEntity();
}
