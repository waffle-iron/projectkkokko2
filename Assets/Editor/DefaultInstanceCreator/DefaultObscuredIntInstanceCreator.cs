using CodeStage.AntiCheat.ObscuredTypes;
using Entitas.VisualDebugging.Unity.Editor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;

class DefaultObscuredIntInstanceCreator: IDefaultInstanceCreator, ITypeDrawer
{

    public bool HandlesType (Type type)
    {
        return type == typeof(CodeStage.AntiCheat.ObscuredTypes.ObscuredInt);
    }

    public object CreateDefault (Type type)
    {
        // TODO return an instance of type CodeStage.AntiCheat.ObscuredTypes.ObscuredInt
        ObscuredInt def = 0;
        return def;
    }

    public object DrawAndGetNewValue (Type memberType, string memberName, object value, object target)
    {
        var obj = (ObscuredInt)value;
        obj = EditorGUILayout.IntField(memberName, obj);
        return obj;
    }
}


