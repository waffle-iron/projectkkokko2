using CodeStage.AntiCheat.ObscuredTypes;
using Entitas.VisualDebugging.Unity.Editor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;

class DefaultObscuredBoolInstanceCreator : IDefaultInstanceCreator, ITypeDrawer
{

    public bool HandlesType (Type type)
    {
        return type == typeof(CodeStage.AntiCheat.ObscuredTypes.ObscuredBool);
    }

    public object CreateDefault (Type type)
    {
        // TODO return an instance of type CodeStage.AntiCheat.ObscuredTypes.ObscuredBool
        ObscuredBool def = false;
        return def;
    }

    public object DrawAndGetNewValue (Type memberType, string memberName, object value, object target)
    {
        var obj = (ObscuredBool)value;
        obj = EditorGUILayout.Toggle(memberName, obj);
        return obj;
    }
}

