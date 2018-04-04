using Entitas.VisualDebugging.Unity.Editor;
using System;
using UnityEditor;
using System.Collections.Generic;

public class DefaultGameStateInstanceCreator : IDefaultInstanceCreator, ITypeDrawer
{

    public bool HandlesType (Type type)
    {
        return type == typeof(GameState);
    }

    public object CreateDefault (Type type)
    {
        // TODO return an instance of type CodeStage.AntiCheat.ObscuredTypes.ObscuredBool
        var def = new GameState();
        return def;
    }

    public object DrawAndGetNewValue (Type memberType, string memberName, object value, object target)
    {
        var obj = (GameState)value;
        var newState = EditorGUILayout.IntPopup("Active: ", obj.state, Enum.GetNames(obj.type), (int[])Enum.GetValues(obj.type));
        //EditorGUILayout.LabelField($"Current: {Enum.GetName(obj.type, obj.state)}");
        EditorGUILayout.LabelField($"Type: {obj.type.ToString()}");
        return new GameState(newState, obj.type);
    }
}