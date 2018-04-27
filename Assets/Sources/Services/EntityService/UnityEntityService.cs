using System;
using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine;

public partial class UnityEntityService : IEntityService
{
    private readonly Dictionary<string, IEntityConfig> _configs;
    private readonly Contexts _contexts;

    public UnityEntityService (Contexts contexts)
    {
        _contexts = contexts;

        //List<IEntityConfig> loadedConfigs = new List<IEntityConfig>();
        _configs = new Dictionary<string, IEntityConfig>();
        var results = Resources.LoadAll<UnityEntityConfig>("");
        foreach (var result in results)
        {
            Add(result);
        }
    }

    public bool Add (IEntityConfig config)
    {
        IEntityConfig value = null;
        if (config == null) { return false; }
        try
        {
            if (_configs.TryGetValue(config.Name, out value))
            {
                //do not add
                Debug.LogWarning($"duplicate Name: {config.Name}");
                return false;
            }
            else
            {
                _configs.Add(config.Name, config);
                return true;
            }
        }
        catch (ArgumentException e)
        {
            Debug.LogWarning($"duplicate ID: {config.Name}\n{e.Message}");
            return false;
        }
        catch (NullReferenceException e)
        {
            Debug.LogError(e.Message);
            return false;
        }

    }

    public bool Get (string name, out IEntity entity)
    {
        IEntityConfig result = null;
        entity = null;
        if (_configs.TryGetValue(name, out result))
        {
            entity = result.Create(_contexts);
            return true;
        }
        Debug.LogWarning($"entity config: {name.ToString()} not found.");
        return false;
    }

    public bool Get (string name)
    {
        IEntity temp;
        return Get(name, out temp);
    }

    public bool Append (string name, IEntity entity)
    {
        IEntity temp;
        Get(name, out temp);

        if (temp != null)
        {
            //append logic
            return true;
        }
        return false;
    }

    public bool Remove (string name, IEntity entity)
    {
        IEntity temp;
        Get(name, out temp);

        if (temp != null)
        {
            //remove logic
            return true;
        }
        return false;
    }
}

