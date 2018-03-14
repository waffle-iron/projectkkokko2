using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class SceneEntitiesInitializer : MonoBehaviour
{
    [SerializeField]
    private EntityCfgID[] entities;

    private InputContext _input;

    private void Awake ()
    {
        _input = Contexts.sharedInstance.input;
    }

    // Use this for initialization
    void Start ()
    {
        foreach (var ety in entities)
        {
            _input.CreateEntity().AddCreateEntity(ety);
        }
    }
}
