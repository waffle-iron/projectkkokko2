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
        return Resources.LoadAll<InitSceneConfig>(_configPath);
    }
}

