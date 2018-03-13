using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class SceneInitializer : MonoBehaviour
{
    [SerializeField]
    private EntityCfgID[] entities;

    private MetaContext _meta;

    private void Awake ()
    {
        _meta = Contexts.sharedInstance.meta;
    }

    // Use this for initialization
    void Start ()
    {
        foreach (var ety in entities)
        {
            IEntity newEntity;
            _meta.entityService.instance.Get(ety, out newEntity);
        }
    }
}
