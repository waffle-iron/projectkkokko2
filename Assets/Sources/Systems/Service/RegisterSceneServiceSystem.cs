using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class RegisterSceneServiceSystem : IInitializeSystem
{
    private readonly MetaContext _meta;
    private readonly ILoadSceneService _service;

    public RegisterSceneServiceSystem (Contexts contexts, ILoadSceneService service)
    {
        this._meta = contexts.meta;
        this._service = service;
    }

    public void Initialize ()
    {
        _meta.SetLoadSceneService(_service);
    }
}