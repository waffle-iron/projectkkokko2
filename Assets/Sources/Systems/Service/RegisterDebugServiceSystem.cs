using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class RegisterDebugServiceSystem : IInitializeSystem
{
    private readonly MetaContext _meta;
    private readonly IDebugService _service;

    public RegisterDebugServiceSystem(Contexts contexts, IDebugService service)
    {
        _meta = contexts.meta;
        _service = service;
    }

    public void Initialize()
    {
        // Initialization code here
        _meta.SetDebugService(_service);
    }
}