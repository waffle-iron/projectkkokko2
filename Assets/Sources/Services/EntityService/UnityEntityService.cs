using System;
using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine;

public partial class UnityEntityService : IEntityService
{
    private readonly Dictionary<string, IEntityConfig> _configs;

    public UnityEntityService (string configPath)
    {
        var loadedConfigs = Resources.LoadAll<ScriptableObject>(configPath)
            .Where(obj => obj is IEntityConfig)
            .Select(obj => obj as IEntityConfig)
            .ToArray();

        _configs = new Dictionary<string, IEntityConfig>();

        foreach (var cfg in loadedConfigs)
        {
            _configs.Add(cfg.Name, cfg);
        }
    }

    public bool Get (string name, out IEntity entity)
    {
        IEntityConfig result = null;
        entity = null;
        if (_configs.TryGetValue(name, out result))
        {
            entity = result.Create();
            return true;
        }
        return false;
    }
}

