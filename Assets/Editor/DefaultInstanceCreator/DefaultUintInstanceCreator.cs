using System;
using Entitas.VisualDebugging.Unity.Editor;
using CodeStage.AntiCheat.ObscuredTypes;
using UnityEditor;
using UnityEngine;

public class DefaultUintInstanceCreator : IDefaultInstanceCreator, ITypeDrawer
{

    public bool HandlesType (Type type)
    {
        return type == typeof(uint);
    }

    public object CreateDefault (Type type)
    {
        // TODO return an instance of type CodeStage.AntiCheat.ObscuredTypes.ObscuredString
        return 0;
    }

    public object DrawAndGetNewValue (Type memberType, string memberName, object value, object target)
    {
        var obj = (uint)value;
        var newValue = EditorGUILayout.IntField(memberName, (int)obj);
        obj = newValue < 0 ? 0 : (uint)newValue;
        return obj;
    }
}
