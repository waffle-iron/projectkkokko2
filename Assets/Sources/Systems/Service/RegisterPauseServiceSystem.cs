using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class RegisterPauseServiceSystem : IInitializeSystem
{
    private readonly MetaContext _meta;
    private IPauseService _service;

    public RegisterPauseServiceSystem (Contexts contexts, IPauseService service)
    {
        _meta = contexts.meta;
        _service = service;
    }

    public void Initialize ()
    {
        // Initialization code here
        _meta.SetPauseService(_service);
    }
}