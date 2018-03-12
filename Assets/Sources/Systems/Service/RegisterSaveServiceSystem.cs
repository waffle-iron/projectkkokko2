using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class RegisterSaveServiceSystem : IInitializeSystem
{
    private readonly MetaContext _meta;
    private readonly ISavingService _service;

    public RegisterSaveServiceSystem (Contexts contexts, ISavingService service)
    {
        this._meta = contexts.meta;
        this._service = service;
    }

    public void Initialize ()
    {
        // Initialization code here
        _meta.SetSaveService(_service);
    }
}