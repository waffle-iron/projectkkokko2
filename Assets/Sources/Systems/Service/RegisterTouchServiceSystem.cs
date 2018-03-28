using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class RegisterTouchServiceSystem : IInitializeSystem
{
    private readonly MetaContext _meta;
    private readonly IInputTouchService _service;

    public RegisterTouchServiceSystem (Contexts contexts, IInputTouchService service)
    {
        this._meta = contexts.meta;
        this._service = service;
    }

    public void Initialize ()
    {
        // Initialization code here
        _meta.SetTouchService(_service);
    }
}