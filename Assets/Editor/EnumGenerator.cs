using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using System.Linq;

public class EnumGenerator
{

    [MenuItem("Project/Create/Refresh Entity Config List")]
    public static void GenEntitylist ()
    {
        string enumFileName = "EntityConfigList";
        string enumName = "EntityCfgID";
        string[] enumEntries = GetEntityConfigs("Assets/Sources/Configs", "t:UnityEntityConfig");
        string filePathAndName = "Assets/Sources/Configs/" + enumFileName + ".cs"; //create folder first

        CreateEnum(filePathAndName, enumName, enumEntries);
    }

    //[MenuItem("Project/Create/Refresh Accessory ID List")]
    //public static void GenAccessoryIDs()
    //{
    //    string enumFileName = "AccessoryID";
    //    string enumName = "AccessoryID";
    //    string[] enumEntries = GetEntityConfigs("Assets/Sources/Configs", "t:AccessoryConfig");
    //    string filePathAndName = "Assets/Sources/Utilities/Items/" + enumFileName + ".cs"; //create folder first

    //    CreateEnum(filePathAndName, enumName, enumEntries);
    //}

    static string[] GetEntityConfigs (string folder, string typeFilter)
    {
        return AssetDatabase.FindAssets(typeFilter, new string[] { folder })
            .Select(guid => AssetDatabase.GUIDToAssetPath(guid))
            .Select(path => AssetDatabase.LoadAssetAtPath<UnityEntityConfig>(path).name)
            .ToArray();
    }

    static void CreateEnum (string filePath, string enumName, string[] enumEntries)
    {
        using (StreamWriter streamWriter = new StreamWriter(filePath))
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
}
