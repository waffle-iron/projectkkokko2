//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiInterfaceGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial interface INeedEntity {

    NeedComponent need { get; }
    bool hasNeed { get; }

    void AddNeed(NeedType newType, ActionType newAction);
    void ReplaceNeed(NeedType newType, ActionType newAction);
    void RemoveNeed();
}
