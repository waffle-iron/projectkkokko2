using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class RegisterEntityServiceSystem : IInitializeSystem
{
    private readonly MetaContext _meta;
    private readonly IEntityService _service;

    public RegisterEntityServiceSystem (Contexts contexts, IEntityService service)
    {
        _meta = contexts.meta;
        _service = service;
    }

    public void Initialize ()
    {
        _meta.SetEntityService(_service);
    }
}