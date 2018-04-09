using CodeStage.AntiCheat.ObscuredTypes;
using Entitas.VisualDebugging.Unity.Editor;
using System;
using UnityEditor;
using UnityEngine;
using System.Linq;

class DefaultTouchDataInstanceCreator : IDefaultInstanceCreator, ITypeDrawer
{

    public bool HandlesType (Type type)
    {
        return type == typeof(TouchData);
    }

    public object CreateDefault (Type type)
    {
        // TODO return an instance of type CodeStage.AntiCheat.ObscuredTypes.ObscuredInt
        var data = new TouchData(-1, Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero, TouchPhase.Canceled, 0, null);
        return data;
    }

    public object DrawAndGetNewValue (Type memberType, string memberName, object value, object target)
    {
        var obj = (TouchData)value;

        var newID = EditorGUILayout.IntField("ID", obj.Id);
        var newScreenPos = EditorGUILayout.Vector3Field("ScreenPos", obj.ScreenPosition);
        var newWorldPos = EditorGUILayout.Vector3Field("WorldPos", obj.WorldPosition);
        var newScreenDelta = EditorGUILayout.Vector3Field("Delta ScreenPos", obj.DeltaScreenPosition);
        var newWorldDelta = EditorGUILayout.Vector3Field("Delta WorldPos", obj.DeltaWorldPosition);
        var newPhase = EditorGUILayout.EnumPopup("Phase", obj.Phase);
        var newTime = EditorGUILayout.DoubleField("Touch Time", obj.TouchTime);
        if (obj.Hits == null || obj.Hits.Length == 0)
        {
            EditorGUILayout.LabelField("Raycasts", 0.ToString());
        }
        else
        {
            var list = "";
            foreach (var hit in obj.Hits)
            {
                list += $"{hit.transform.name}, ";
            }
            EditorGUILayout.LabelField("Raycasts", $"{list}");
        }

        var newObj = new TouchData(newID, newScreenPos, newWorldPos, newScreenDelta, newWorldDelta, (TouchPhase)newPhase, newTime, obj.Hits);

        return newObj;
    }
}


