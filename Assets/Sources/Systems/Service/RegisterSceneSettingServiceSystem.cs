using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class RegisterSceneSettingServiceSystem : IInitializeSystem
{
    private readonly MetaContext _meta;
    private readonly ISceneSettingService _service;

    public RegisterSceneSettingServiceSystem (Contexts contexts, ISceneSettingService service)
    {
        _meta = contexts.meta;
        _service = service;
    }

    public void Initialize ()
    {
        _meta.SetSceneSettingService(_service);
    }
}