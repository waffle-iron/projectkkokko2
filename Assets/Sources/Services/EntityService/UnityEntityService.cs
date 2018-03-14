using System;
using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine;

public partial class UnityEntityService : IEntityService
{
    private readonly Dictionary<EntityCfgID, IEntityConfig> _configs;
    private readonly Contexts _contexts;

    public UnityEntityService (string[] configPath, Contexts contexts)
    {
        _contexts = contexts;

        //List<IEntityConfig> loadedConfigs = new List<IEntityConfig>();
        _configs = new Dictionary<EntityCfgID, IEntityConfig>();

        foreach (var path in configPath)
        {
            var loadedConfigs = Resources.LoadAll<ScriptableObject>(path)
            .Where(obj => obj is IEntityConfig)
            .Select(obj => obj as IEntityConfig)
            .ToArray();

            foreach (var cfg in loadedConfigs)
            {
                IEntityConfig value = null;
                try
                {
                    if (_configs.TryGetValue(cfg.Name, out value))
                    {
                        throw new ArgumentException();
                    }
                    else
                    {
                        cfg.srcPath = path;
                        _configs.Add(cfg.Name, cfg);
                    }
                }
                catch (ArgumentException e)
                {
                    Debug.LogError($"duplicate ID: {cfg.Name} from {path} and {value.srcPath}\n{e.Message}");
                }
            }
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

