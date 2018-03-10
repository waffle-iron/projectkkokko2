using System;
using Entitas.VisualDebugging.Unity.Editor;
using CodeStage.AntiCheat.ObscuredTypes;
using UnityEditor;

public class DefaultObscuredStringInstanceCreator : IDefaultInstanceCreator, ITypeDrawer {

    public bool HandlesType(Type type) {
        return type == typeof(CodeStage.AntiCheat.ObscuredTypes.ObscuredString);
    }

    public object CreateDefault(Type type) {
        // TODO return an instance of type CodeStage.AntiCheat.ObscuredTypes.ObscuredString
        ObscuredString def = "";
        return def;
    }

    public object DrawAndGetNewValue (Type memberType, string memberName, object value, object target)
    {
        var obj = (ObscuredString)value;
        obj = EditorGUILayout.TextField(memberName, obj);
        return obj;
    }
}
