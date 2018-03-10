using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class RegisterTimeServiceSystem : IInitializeSystem
{
    private readonly MetaContext _meta;
    private readonly ITimeService _service;

    public RegisterTimeServiceSystem (Contexts contexts, ITimeService service)
    {
        this._meta = contexts.meta;
        this._service = service;
    }

    public void Initialize ()
    {
        // Initialization code here
        _meta.SetTimeService(_service);
    }
}