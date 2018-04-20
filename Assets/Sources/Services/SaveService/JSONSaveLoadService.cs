using System;
using System.Collections.Generic;
using System.Linq;
using CodeStage.AntiCheat.ObscuredTypes;
using Entitas;
using Newtonsoft.Json;
using UnityEngine;

public class JSONSaveLoadService : ISavingService
{
    private readonly EntitySaveLoader _loader;

    public JSONSaveLoadService ()
    {
        _loader = new EntitySaveLoader(null);
        _loader.ReLoadTemplets();
    }

    EntityTemplate LoadData (string id)
    {
        var data = ObscuredPrefs.GetString(id, "");
        if (data.Equals("")) { return null; }

        return JsonConvert.DeserializeObject<EntityTemplate>(data);
    }

    public bool LoadExisting (ObscuredString id, IEntity entity)
    {
        var data = LoadData(id);
        if (data != null)
        {
            _loader.AddComponentsFromEntityInfo(entity, data);
            return true;
        }
        return false;
    }

    public bool LoadNew (ObscuredString id, Contexts contexts)
    {
        var data = LoadData(id);
        if (data != null)
        {
            _loader.MakeEntityFromEntityInfo(data, contexts);
            return true;
        }
        return false;
    }

    public bool Save (ObscuredString id, IEntity entity)
    {
        try
        {
            var json = JsonConvert.SerializeObject(_loader.MakeEntityInfo(entity, null), Formatting.Indented);
            ObscuredPrefs.SetString(id, json);
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
            return false;
        }

        return true;
    }
}

