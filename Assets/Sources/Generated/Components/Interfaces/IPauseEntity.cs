//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiInterfaceGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial interface IPauseEntity {

    PauseComponent pause { get; }
    bool hasPause { get; }

    void AddPause(bool newState);
    void ReplacePause(bool newState);
    void RemovePause();
}
