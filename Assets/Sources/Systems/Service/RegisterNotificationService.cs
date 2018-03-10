using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class RegisterNotificationService : IInitializeSystem
{
    private readonly MetaContext _meta;
    private INotificationService _service;

    public RegisterNotificationService (Contexts contexts, INotificationService service)
    {
        this._meta = contexts.meta;
        this._service = service;
    }

    public void Initialize ()
    {
        // Initialization code here
        _meta.SetNotificationService(_service);
    }
}