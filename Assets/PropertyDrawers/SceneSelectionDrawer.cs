using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

[CustomPropertyDrawer(typeof(SceneNameAttribute))]
public class SceneSelectionDrawer : PropertyDrawer
{
    int selection = 0;

    public override void OnGUI (Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        if (property.propertyType != SerializedPropertyType.String)
        {
            Debug.LogError($"please use SceneSelectionDrawer on string type only");
        }

        int numScenes = SceneManager.sceneCountInBuildSettings;
        var sceneNames = new string[numScenes];

        for (int i = 0; i < numScenes; ++i)
        {
            sceneNames[i] = System.IO.Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i));
            if (property.stringValue.Equals(sceneNames[i]))
            {
                selection = i;
            }
        }

        var pos = EditorGUI.PrefixLabel(position, label);
        selection = EditorGUI.Popup(pos, selection, sceneNames);
        property.stringValue = sceneNames[selection];

        EditorGUI.EndProperty();
    }
}
