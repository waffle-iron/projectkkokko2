//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiInterfaceGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial interface ICurrentEntity {

    CurrentComponent current { get; }
    bool hasCurrent { get; }

    void AddCurrent(int newAmount);
    void ReplaceCurrent(int newAmount);
    void RemoveCurrent();
}
