//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiInterfaceGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial interface IChangeScoreEntity {

    ChangeScoreComponent changeScore { get; }
    bool hasChangeScore { get; }

    void AddChangeScore(int newValue, OperationType newOperation);
    void ReplaceChangeScore(int newValue, OperationType newOperation);
    void RemoveChangeScore();
}
