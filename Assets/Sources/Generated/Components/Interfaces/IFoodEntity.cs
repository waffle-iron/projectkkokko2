//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiInterfaceGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial interface IFoodEntity {

    FoodComponent food { get; }
    bool hasFood { get; }

    void AddFood(string newId, float newRecovery);
    void ReplaceFood(string newId, float newRecovery);
    void RemoveFood();
}
