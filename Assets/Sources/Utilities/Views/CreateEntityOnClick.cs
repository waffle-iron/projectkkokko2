using UnityEngine;
using System.Collections;

public class CreateEntityOnClick : MonoBehaviour
{
    [SerializeField]
    private string _entity;
    
    public void Execute ()
    {
        Contexts.sharedInstance.meta.entityService.instance.Get(_entity);
    }
}
