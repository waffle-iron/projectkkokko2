using System;
using System.Collections.Generic;
using UnityEngine;

public class UnitySceneSettingService : ISceneSettingService
{
    private readonly string _configPath;

    public UnitySceneSettingService (string configPath)
    {
        _configPath = configPath;
    }

    public InitSceneConfig[] GetAll ()
    {
        var configs = Resources.LoadAll<InitSceneConfig>(_configPath);
        if (configs == null) { Debug.LogError($"no configs found in path {_configPath}"); }
        return configs;
    }
}

