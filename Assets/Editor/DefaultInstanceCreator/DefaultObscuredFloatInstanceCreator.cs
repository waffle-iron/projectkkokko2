using CodeStage.AntiCheat.ObscuredTypes;
using Entitas.VisualDebugging.Unity.Editor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;

namespace Assets
{
    class DefaultObscuredFloatInstanceCreator : IDefaultInstanceCreator, ITypeDrawer
    {

        public bool HandlesType (Type type)
        {
            return type == typeof(CodeStage.AntiCheat.ObscuredTypes.ObscuredFloat);
        }

        public object CreateDefault (Type type)
        {
            // TODO return an instance of type CodeStage.AntiCheat.ObscuredTypes.ObscuredFloat
            ObscuredFloat def = 0.0f;
            return def;
        }

        public object DrawAndGetNewValue (Type memberType, string memberName, object value, object target)
        {
            var obj = (ObscuredFloat)value;
            obj = EditorGUILayout.FloatField(memberName, obj);
            return obj;
        }
    }

}
