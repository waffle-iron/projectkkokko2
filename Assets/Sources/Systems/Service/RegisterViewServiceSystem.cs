using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class RegisterViewServiceSystem : IInitializeSystem
{
    private readonly MetaContext _meta;
    private readonly IViewService _service;

    public RegisterViewServiceSystem (Contexts contexts, IViewService service)
    {
        this._meta = contexts.meta;
        this._service = service;
    }

    public void Initialize ()
    {
        _meta.SetViewService(_service);
        _service.Refresh("", true);
    }
}