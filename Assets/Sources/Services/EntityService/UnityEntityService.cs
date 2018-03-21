using System;
using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine;

public partial class UnityEntityService : IEntityService
{
    private readonly Dictionary<EntityCfgID, IEntityConfig> _configs;
    private readonly Contexts _contexts;

    public UnityEntityService (Contexts contexts)
    {
        _contexts = contexts;

        //List<IEntityConfig> loadedConfigs = new List<IEntityConfig>();
        _configs = new Dictionary<EntityCfgID, IEntityConfig>();

    }

    public bool Add (IEntityConfig config)
    {

        IEntityConfig value = null;
        try
        {
            if (_configs.TryGetValue(config.Name, out value))
            {
                throw new ArgumentException();
            }
            else
            {
                _configs.Add(config.Name, config);
                return true;
            }
        }
        catch (ArgumentException e)
        {
            Debug.LogError($"duplicate ID: {config.Name}\n{e.Message}");
            return false;
        }

    }

    public bool Get (EntityCfgID name, out IEntity entity)
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

    public bool Get (EntityCfgID name)
    {
        IEntity temp;
        return Get(name, out temp);
    }
}

