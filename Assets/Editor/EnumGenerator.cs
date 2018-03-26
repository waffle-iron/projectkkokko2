using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using System.Linq;

public class EnumGenerator
{

    [MenuItem("Project/Create/Refresh Entity Config List")]
    public static void Gen ()
    {
        string enumFileName = "EntityConfigList";
        string enumName = "EntityCfgID";
        string[] enumEntries = GetEntityConfigs("Assets/Sources/Configs");
        string filePathAndName = "Assets/Sources/Configs/" + enumFileName + ".cs"; //create folder first

        using (StreamWriter streamWriter = new StreamWriter(filePathAndName))
        {
            streamWriter.WriteLine("public enum " + enumName);
            streamWriter.WriteLine("{");
            for (int i = 0; i < enumEntries.Length; i++)
            {
                streamWriter.WriteLine("\t" + enumEntries[i] + ",");
            }
            streamWriter.WriteLine("}");
        }
        AssetDatabase.Refresh();

    }

    static string[] GetEntityConfigs (string folder)
    {
        return AssetDatabase.FindAssets("t:UnityEntityConfig", new string[] { folder })
            .Select(guid => AssetDatabase.GUIDToAssetPath(guid))
            .Select(path => AssetDatabase.LoadAssetAtPath<UnityEntityConfig>(path).name)
            .ToArray();
    }
}
